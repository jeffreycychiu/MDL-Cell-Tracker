using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenCvSharp;
using System.Diagnostics;
using Microsoft.VisualBasic;

//Written by: Jeffrey Chiu
//July 28 2015x`

namespace MDL_Cell_Tracker
{
    public partial class Form1 : Form
    {
        int currentImage = 0;
        int numImages = 0;
        int cellNumber = 1;
        int totalNumCells = 1;
        double zoomScale = 1;
        int originalPictureWidth, originalPictureHeight;
        const int ROI_CIRCLE_DIAM = 14;
        List<String> imageFilePath = new List<string>();
        List<positionData> outputData = new List<positionData>();

        //Colors for the first 20 cells
        string[] colorArray = { "Red", "Blue", "Green", "Yellow", "Cyan", "Pink", "Burlywood", "Lime", "Lightskyblue", "Brown",
                                "Cornsilk", "Darkblue", "Darkcyan", "DarkSalmon", "Deeppink", "Goldenrod", "Indianred", "Mediumspringgreen",
                                "Mistyrose", "Palegreen", "Sandybrown", "Teal", "Thistle", "Tomato", "Turquoise"};

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            cellNumberLabel.Text = "CELL #: " + cellNumber.ToString();
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
        }

        //Select folder that contains the pictures needed to be analyzed
        //Writes folder path to textbox1
        private void imageFolderBtn(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                textBox1.Text = folderPath;
                DirectoryInfo directInfo = new DirectoryInfo(folderPath);

                //Searches folder for bitmap (.bmp) files. Loads an array with file names, and counts the total number of bmp files
                foreach (var imageFile in directInfo.GetFiles("*.bmp"))
                {
                    //Fill the list with the paths of all the pictures
                    imageFilePath.Add(imageFile.FullName);
                    listBox1.Items.Add(imageFile.Name);
                    numImages++;
                    updateImage();          
                }

                //load the first image into the picture box
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                originalPictureWidth = pictureBox1.Width;
                originalPictureHeight = pictureBox1.Height;
                updateImage();
                panel1.Controls.Add(pictureBox1);                

            }
        }
        
        //Toggle between images
        private void nextBtn_Click(object sender, EventArgs e)
        {
            currentImage++;
            if (currentImage > (numImages-1))
                currentImage = 0;
            updateImage();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            currentImage--;
            if (currentImage < 0)
                currentImage = numImages - 1;
            updateImage();
        }


        //Update the image displayed in the picturebox and the "Image: current/total" Label
        //TODO: select the current image on the listboxs
        public void updateImage()
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();

            Image image = Image.FromFile(imageFilePath[currentImage]);

            //Convert if indexed to non-indexed - NOTE: only converts 8bppIndexed right now because I didn't have any other images to test - Jeff 2018/04/14
            if (image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            {
                pictureBox1.Image = Indexed2Image(image, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            }
            else
            {
                pictureBox1.Image = image;
            }
            

            //Draw all the circles of the previous images. For example, if you are on image number 20, it will draw the circles from images 1 to 19
            //Might have performance issues in this method once we start getting to the upper data points
            //TODO: Draw line between each point as well
            if (showPrevCheckBox.Checked)
            {
                int xLast=0, yLast=0;
                foreach (var prevDataPoint in outputData)
                {
                    //Draw connecting lines to each dot
                    if (prevDataPoint.pictureNum <= currentImage + 1)
                    {
                        DrawCircle(prevDataPoint.xPosition, prevDataPoint.yPosition, prevDataPoint.cell);
                        if (prevDataPoint.pictureNum == 1)
                        {
                            xLast = prevDataPoint.xPosition;
                            yLast = prevDataPoint.yPosition;
                        }
                        else
                            DrawLine(xLast, yLast, prevDataPoint.xPosition, prevDataPoint.yPosition, prevDataPoint.cell);
                    }
                    xLast = prevDataPoint.xPosition;
                    yLast = prevDataPoint.yPosition;

                    //Draw the number of the cell next to the latest number
                    /*
                    if (prevDataPoint.pictureNum == currentImage + 1)
                    {
                        DrawCell(prevDataPoint.xPosition, prevDataPoint.yPosition, prevDataPoint.cell);
                    }
                    */
                }
            }
            else
            {
                foreach (var prevDataPoint in outputData)
                {
                    if (prevDataPoint.pictureNum == currentImage + 1)
                        DrawCircle(prevDataPoint.xPosition, prevDataPoint.yPosition, prevDataPoint.cell);
                }
            }

            //Draw the number of the cell of the last point in each cell number series
            for (int i = 1; i <= totalNumCells; i++)
            {
                positionData lastCellInSeries = new positionData();
                lastCellInSeries = outputData.Where(dataPoint => dataPoint.cell == i).Where(datapoint => datapoint.pictureNum <= currentImage + 1).OrderByDescending(x => x.pictureNum).FirstOrDefault();
                if (lastCellInSeries != null)
                    DrawCell(lastCellInSeries.xPosition, lastCellInSeries.yPosition, lastCellInSeries.cell);
            }
            
            //Update the image ##/## label
            imageLabel.Text = "Image: " + (currentImage+1).ToString() + "/" + numImages.ToString();
            //Update the cell # label
            cellNumberLabel.Text = "CELL #: " + cellNumber.ToString();
        }

        public static Image Indexed2Image(Image img, System.Drawing.Imaging.PixelFormat fmt)
        {
            Image bmp = new Bitmap(img.Width, img.Height, fmt);
            Graphics gr = Graphics.FromImage(bmp);
            gr.DrawImage(img, 0, 0);
            gr.Dispose();
            return bmp;
        }


        //Keyboard shortcuts for previous and next image
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
                prevBtn.PerformClick();
            if (keyData == Keys.Right)
                nextBtn.PerformClick();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Write X and Y coordinates of the mouse click to a csv file
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Drawing.Point point = pictureBox1.PointToClient(Cursor.Position);

                int xPos = (int) (point.X / zoomScale);
                int yPos = (int) (point.Y / zoomScale);
                //Calculate the centroid of the ROI if the auto-centre option is on. Alter the x and y position.
                if (autoCentreCheckBox.Checked)
                    calculateCentrePoint(xPos, yPos, out xPos, out yPos);
                    //calculateCentrePoint(point.X, point.Y, out xPos, out yPos);

                //Search the list of output data for a point with the same cell number and picture number. If it exists, replace it with
                //the new point that was just clicked.
                int index = outputData.FindIndex(positionData => positionData != null && positionData.pictureNum == currentImage + 1 &&
                   positionData.cell == cellNumber);

                if (index != -1)
                {
                    outputData[index] = new positionData { cell = cellNumber, pictureNum = currentImage + 1, xPosition = xPos, yPosition = yPos };
                }
                else //add the datapoint to the list if it doesn't exist
                {
                    outputData.Add(new positionData
                    {
                        cell = cellNumber,
                        pictureNum = currentImage + 1,
                        xPosition = xPos,
                        yPosition = yPos
                    });
                }
                //Sort the list. First by cell number and then by picture number.
                outputData = outputData.OrderBy(x => x.cell).ThenBy(x => x.pictureNum).ToList();
                //Draw a points and lines connecting
                updateImage();
            }

            //Delete current point if the mouse click was a right click
            else if (e.Button == MouseButtons.Right)
            {
                //Search the list of output data for a point with the same cell number and picture number. If it exists, delete the point
                int index = outputData.FindIndex(positionData => positionData != null && positionData.pictureNum == currentImage + 1 &&
                   positionData.cell == cellNumber);
                if (index != -1)
                {
                    outputData.RemoveAt(index); //Delete the point 
                    updateImage();
                }
            }
        }

        //Change the CELL NUMBER. Expected to randomly select about 20 cells to track for each set of data.
        private void cellPrevBtn_Click(object sender, EventArgs e)
        {
            cellNumber--;
            if (cellNumber < 1)
                cellNumber = 1;
            updateImage();
        }

        private void cellNextBtn_Click(object sender, EventArgs e)
        {
            cellNumber++;
            if (cellNumber > totalNumCells)
                totalNumCells = cellNumber;
            currentImage = 0;
            updateImage();
        }

        //Export all the recorded data to a csv file to the same directory that the images are loaded from
        //the output format is CELL NUMBER | PICTURE NUMBER | X POSITION | Y POSITION
        private void exportDataBtn_Click(object sender, EventArgs e)
        {
            var csv = new StringBuilder();

            string header = string.Format("{0},{1},{2},{3}", "CELL NUMBER", "PICTURE NUMBER", "X POSITION", "Y POSITION\n");
            csv.Append(header);

            foreach (var dataPoint in outputData)
            {
                var cell = dataPoint.cell.ToString();
                var pictureNum = dataPoint.pictureNum.ToString();
                var xPos = dataPoint.xPosition.ToString();
                var yPos = dataPoint.yPosition.ToString();
                var newLine = string.Format("{0},{1},{2},{3}",cell, pictureNum, xPos, yPos + "\n");
                csv.Append(newLine);
            }

            //Write all data to a csv file in the same directory as the images. Title of the csv file is outputData_Date_Time
            //MessageBox.Show(textBox1.Text);
            try
            {
                File.WriteAllText(textBox1.Text + "/outputData" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".csv", csv.ToString());
            }
            catch(IOException)
            {
                MessageBox.Show("Failed to write data");
            }

            MessageBox.Show("Data Exported! :)");
        }

        //Change the cursor icon when it enters and leaves the picturebox so it is easier to select the centre of the cell
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Default;
        }

        //Adds zooming in and out using the mousewheel on the picturebox
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            int zoomRatio = 10;
            int widthZoom, heightZoom;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (e.Delta > 0)
            {
                widthZoom = pictureBox1.Width * zoomRatio / 100;
                heightZoom = pictureBox1.Height * zoomRatio / 100;
                pictureBox1.Width += widthZoom;
                pictureBox1.Height += heightZoom;

            }
            else if (e.Delta < 0)
            {
                widthZoom = pictureBox1.Width * zoomRatio / 100;
                heightZoom = pictureBox1.Height * zoomRatio / 100;
                pictureBox1.Width -= widthZoom;
                pictureBox1.Height -= heightZoom;
            }
            zoomScale = (double)pictureBox1.Width / (double)originalPictureWidth;
        }

        //Selects the colour for the drawing operation. First 20 cells have defined colour, then random colours after that
        private void penColorPicker(int numCell, out Color penColor)
        {
            if (numCell < 20)
            {
                penColor = Color.FromName(colorArray[numCell - 1]);
            }
            else
            {
                Random randomGen = new Random();
                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                penColor = Color.FromKnownColor(randomColorName);
            }
        }

        //Draws a circle at the given points, differenc colour for each CELL NUMBER
        private void DrawCircle(int xPos, int yPos, int numCell)
        {
            //Change the color depending on the cell number. First 20 cells have defined colour, then random colors
            Color penColor;
            penColorPicker(numCell, out penColor);
            System.Drawing.Pen myPen = new System.Drawing.Pen(penColor);

            //Draw circle where the mouse clicked  
            
            System.Drawing.Graphics formGraphics;
            formGraphics = Graphics.FromImage(pictureBox1.Image);
            //formGraphics.DrawEllipse(myPen, new Rectangle(xPos-(ROI_CIRCLE_DIAM/2), yPos-(ROI_CIRCLE_DIAM/2), ROI_CIRCLE_DIAM, ROI_CIRCLE_DIAM));
            SolidBrush brush = new SolidBrush(penColor);
            formGraphics.FillRectangle(brush, xPos, yPos, 3, 3);
            myPen.Dispose();
            formGraphics.Dispose();
            brush.Dispose();
        }

        //Draws a line between the x and y coordinates of the two points given. The cell number is used to determine color
        private void DrawLine(int xLast, int yLast, int xCurrent, int yCurrent, int numCell)
        {
            Color penColor;
            penColorPicker(numCell, out penColor);
            System.Drawing.Pen myPen = new System.Drawing.Pen(penColor);
            System.Drawing.Graphics formGraphics;
            formGraphics = Graphics.FromImage(pictureBox1.Image);
            Point point1 = new Point(xLast, yLast);
            Point point2 = new Point(xCurrent, yCurrent);
            formGraphics.DrawLine(myPen, point1, point2);
            
            myPen.Dispose();
            formGraphics.Dispose();
        }

        //Draw the number of the cell a little bit to the right and down of the last point
        private void DrawCell(int xPos, int yPos, int numCell)
        {
            Color penColor;
            penColorPicker(numCell, out penColor);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(penColor);
            System.Drawing.Graphics formGraphics;
            System.Drawing.Font font = new System.Drawing.Font("Arial", 14);
            formGraphics = Graphics.FromImage(pictureBox1.Image);
            formGraphics.DrawString(numCell.ToString(), font, drawBrush, xPos+5, yPos+5);

            font.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }

        //Find the centroid and draw the centre of the circle there
        private void calculateCentrePoint(int xPos, int yPos, out int xCentrePoint, out int yCentrePoint)
        {
            IplImage sourceImage, cannyImage;
            string path = imageFilePath[currentImage];
            Bitmap bitmap = (Bitmap)pictureBox1.Image;

            //sourceImage = new IplImage(path);
            //copy source image from bitmap
            sourceImage = new IplImage(bitmap.Height, bitmap.Width, BitDepth.U8, 3);
            sourceImage = OpenCvSharp.Extensions.BitmapConverter.ToIplImage(bitmap);

            CvRect rectROI = new CvRect(xPos - 15, yPos - 15, 30, 30);
            sourceImage.SetROI(rectROI);

            cannyImage = new IplImage(rectROI.Height, rectROI.Width, BitDepth.U8, 1);

            Cv.Canny(sourceImage, cannyImage, 20, 65, ApertureSize.Size3);

            //Cv.NamedWindow("sampleCanny", CvConst.CV_WINDOW_NORMAL);
            //Cv.ShowImage("sampleCanny", cannyImage);

            //Find the centroid
            double M00, M01, M10;
            int xCentroid, yCentroid;
            CvMoments moment;
            Cv.Moments(cannyImage, out moment, false);
            M00 = moment.M00;
            M01 = moment.M01;
            M10 = moment.M10;
            
            //Check for divide by 0. If all cells are black then M00 will equal 0
            if (M00 != 0)
            {
                xCentroid = Convert.ToInt32(M10 / M00);
                yCentroid = Convert.ToInt32(M01 / M00);
            }
            else
            {
                xCentroid = 0; 
                yCentroid = 0;
            }

            //Calculate the centre point where the point will be drawn
            if (xCentroid != 0)
                xCentrePoint = xPos - rectROI.Width / 2 + xCentroid;
            else
                xCentrePoint = xPos;

            if (yCentroid != 0)
                yCentrePoint = yPos - rectROI.Height / 2 + yCentroid;
            else
                yCentrePoint = yPos;

            /*
            MessageBox.Show("M00: " + M00.ToString() + "\nM01: " + M01.ToString() + "\nM10: " + M10.ToString() + "\nxCentroid: " +
                xCentroid.ToString() + "\nyCentroid: " + yCentroid.ToString() + "\nxCentrePoint: " + xCentrePoint.ToString() +
                "\nyCentrePoint: " + yCentrePoint.ToString());
            */
            
            Cv.ResetImageROI(sourceImage);
            Cv.ReleaseImage(sourceImage);
            Cv.ReleaseImage(cannyImage);
            bitmap.Dispose();
        }

 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            updateImage();
        }

        //Save all pictures in a new folder, with the markers included.
        private void saveImageBtn_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.Combine(folderBrowserDialog1.SelectedPath, "SavedImages\\");
            //MessageBox.Show(path);
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            file.Directory.Create();
            
            for(int i = 0; i < numImages; i++)
            {
                currentImage = i;
                updateImage();
                try
                {
                    pictureBox1.Image.Save(path + "Image" + (i + 1).ToString() + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                }
                catch(IOException)
                {
                    MessageBox.Show("Failed to save images. Make sure all previous images are closed");
                }
            }
            MessageBox.Show("Save Succesful!");
        }

        //Load a csv file and read the datapoints from that. Deletes the current outputData list and replaces it
        //with the datapoints in the CSV.
        private void loadCSVButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Delete the current outputData list
                outputData.Clear();
                loadCSVTextBox.Text = openFileDialog1.FileName;
                using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(openFileDialog1.FileName))
                {
                    parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                    parser.SetDelimiters(",");
                    
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        string[] inputData = new string[4];
                        int column = 0;
                        foreach (string field in fields)
                        {
                            int intCheck;
                            //check if the string is an int - if so record the data, if not do nothing
                            if (int.TryParse(field, out intCheck))
                            {
                                inputData[column] = field;

                                if (column == 3)
                                {
                                    outputData.Add(new positionData
                                    {
                                        cell = Int32.Parse(inputData[0]),
                                        pictureNum = Int32.Parse(inputData[1]),
                                        xPosition = Int32.Parse(inputData[2]),
                                        yPosition = Int32.Parse(inputData[3])
                                    });
                                    column = 0;
                                }
                                column++;
                            }
                        }
                    }
                }
                //Re-calculate the total number of cells
                currentImage = 0;
                cellNumber = 1;
                totalNumCells = outputData.Max(x => x.cell);
                updateImage();

            }
        }

        //Display the x y position of the cursor on the bottom left corner
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = pictureBox1.PointToClient(Cursor.Position);
            string xyPosition = "X:" + point.X + " Y:" + point.Y;
            cursorLabel.Text = xyPosition;
        }
    }

    //Class that stores the information of the location of each cell. This is the data that gets exported.
    public class positionData
    {
        public int cell {get; set;}
        public int pictureNum { get; set; }
        public int xPosition { get; set; }
        public int yPosition { get; set; }
    }
}

