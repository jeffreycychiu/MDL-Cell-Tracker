namespace MDL_Cell_Tracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button imageFolderBtn;
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.imageLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cellNumberLabel = new System.Windows.Forms.Label();
            this.cellPrevBtn = new System.Windows.Forms.Button();
            this.cellNextBtn = new System.Windows.Forms.Button();
            this.exportDataBtn = new System.Windows.Forms.Button();
            this.saveImageBtn = new System.Windows.Forms.Button();
            this.cursorLabel = new System.Windows.Forms.Label();
            this.showPrevCheckBox = new System.Windows.Forms.CheckBox();
            this.autoCentreCheckBox = new System.Windows.Forms.CheckBox();
            this.loadCSVButton = new System.Windows.Forms.Button();
            this.loadCSVTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            imageFolderBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageFolderBtn
            // 
            imageFolderBtn.Location = new System.Drawing.Point(12, 12);
            imageFolderBtn.Name = "imageFolderBtn";
            imageFolderBtn.Size = new System.Drawing.Size(108, 23);
            imageFolderBtn.TabIndex = 0;
            imageFolderBtn.Text = "Image Folder";
            imageFolderBtn.UseVisualStyleBackColor = true;
            imageFolderBtn.Click += new System.EventHandler(this.imageFolderBtn);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 22);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1692, 1066);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // prevBtn
            // 
            this.prevBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prevBtn.Location = new System.Drawing.Point(1026, 12);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(75, 23);
            this.prevBtn.TabIndex = 3;
            this.prevBtn.Text = "Previous";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(1107, 12);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 4;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // imageLabel
            // 
            this.imageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageLabel.AutoSize = true;
            this.imageLabel.Location = new System.Drawing.Point(934, 15);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(86, 17);
            this.imageLabel.TabIndex = 5;
            this.imageLabel.Text = "Image:??/??";
            this.imageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(1045, 59);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(137, 404);
            this.listBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1045, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Loaded Images:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 405);
            this.panel1.TabIndex = 8;
            // 
            // cellNumberLabel
            // 
            this.cellNumberLabel.AutoSize = true;
            this.cellNumberLabel.Location = new System.Drawing.Point(436, 15);
            this.cellNumberLabel.Name = "cellNumberLabel";
            this.cellNumberLabel.Size = new System.Drawing.Size(58, 17);
            this.cellNumberLabel.TabIndex = 9;
            this.cellNumberLabel.Text = "CELL #:";
            // 
            // cellPrevBtn
            // 
            this.cellPrevBtn.Location = new System.Drawing.Point(516, 12);
            this.cellPrevBtn.Name = "cellPrevBtn";
            this.cellPrevBtn.Size = new System.Drawing.Size(75, 23);
            this.cellPrevBtn.TabIndex = 10;
            this.cellPrevBtn.Text = "Previous";
            this.cellPrevBtn.UseVisualStyleBackColor = true;
            this.cellPrevBtn.Click += new System.EventHandler(this.cellPrevBtn_Click);
            // 
            // cellNextBtn
            // 
            this.cellNextBtn.Location = new System.Drawing.Point(597, 12);
            this.cellNextBtn.Name = "cellNextBtn";
            this.cellNextBtn.Size = new System.Drawing.Size(75, 23);
            this.cellNextBtn.TabIndex = 11;
            this.cellNextBtn.Text = "Next";
            this.cellNextBtn.UseVisualStyleBackColor = true;
            this.cellNextBtn.Click += new System.EventHandler(this.cellNextBtn_Click);
            // 
            // exportDataBtn
            // 
            this.exportDataBtn.Location = new System.Drawing.Point(678, 4);
            this.exportDataBtn.Name = "exportDataBtn";
            this.exportDataBtn.Size = new System.Drawing.Size(110, 38);
            this.exportDataBtn.TabIndex = 12;
            this.exportDataBtn.Text = "Export Data";
            this.exportDataBtn.UseVisualStyleBackColor = true;
            this.exportDataBtn.Click += new System.EventHandler(this.exportDataBtn_Click);
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.Location = new System.Drawing.Point(794, 4);
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(101, 38);
            this.saveImageBtn.TabIndex = 13;
            this.saveImageBtn.Text = "Save Images";
            this.saveImageBtn.UseVisualStyleBackColor = true;
            this.saveImageBtn.Click += new System.EventHandler(this.saveImageBtn_Click);
            // 
            // cursorLabel
            // 
            this.cursorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cursorLabel.AutoSize = true;
            this.cursorLabel.Location = new System.Drawing.Point(12, 475);
            this.cursorLabel.Name = "cursorLabel";
            this.cursorLabel.Size = new System.Drawing.Size(94, 17);
            this.cursorLabel.TabIndex = 14;
            this.cursorLabel.Text = "X: ### Y: ###";
            // 
            // showPrevCheckBox
            // 
            this.showPrevCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showPrevCheckBox.AutoSize = true;
            this.showPrevCheckBox.Checked = true;
            this.showPrevCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPrevCheckBox.Location = new System.Drawing.Point(138, 473);
            this.showPrevCheckBox.Name = "showPrevCheckBox";
            this.showPrevCheckBox.Size = new System.Drawing.Size(166, 21);
            this.showPrevCheckBox.TabIndex = 15;
            this.showPrevCheckBox.Text = "Show Prev Movement";
            this.showPrevCheckBox.UseVisualStyleBackColor = true;
            this.showPrevCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // autoCentreCheckBox
            // 
            this.autoCentreCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoCentreCheckBox.AutoSize = true;
            this.autoCentreCheckBox.Checked = true;
            this.autoCentreCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCentreCheckBox.Location = new System.Drawing.Point(310, 471);
            this.autoCentreCheckBox.Name = "autoCentreCheckBox";
            this.autoCentreCheckBox.Size = new System.Drawing.Size(142, 21);
            this.autoCentreCheckBox.TabIndex = 16;
            this.autoCentreCheckBox.Text = "Auto-Centre         ";
            this.autoCentreCheckBox.UseVisualStyleBackColor = true;
            // 
            // loadCSVButton
            // 
            this.loadCSVButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadCSVButton.Location = new System.Drawing.Point(794, 472);
            this.loadCSVButton.Name = "loadCSVButton";
            this.loadCSVButton.Size = new System.Drawing.Size(92, 23);
            this.loadCSVButton.TabIndex = 17;
            this.loadCSVButton.Text = "Load CSV";
            this.loadCSVButton.UseVisualStyleBackColor = true;
            this.loadCSVButton.Click += new System.EventHandler(this.loadCSVButton_Click);
            // 
            // loadCSVTextBox
            // 
            this.loadCSVTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadCSVTextBox.Location = new System.Drawing.Point(892, 472);
            this.loadCSVTextBox.Name = "loadCSVTextBox";
            this.loadCSVTextBox.Size = new System.Drawing.Size(289, 22);
            this.loadCSVTextBox.TabIndex = 18;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1194, 498);
            this.Controls.Add(this.loadCSVTextBox);
            this.Controls.Add(this.loadCSVButton);
            this.Controls.Add(this.autoCentreCheckBox);
            this.Controls.Add(this.showPrevCheckBox);
            this.Controls.Add(this.cursorLabel);
            this.Controls.Add(this.saveImageBtn);
            this.Controls.Add(this.exportDataBtn);
            this.Controls.Add(this.cellNextBtn);
            this.Controls.Add(this.cellPrevBtn);
            this.Controls.Add(this.cellNumberLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(imageFolderBtn);
            this.Name = "Form1";
            this.Text = "Cell Tracking";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label cellNumberLabel;
        private System.Windows.Forms.Button cellPrevBtn;
        private System.Windows.Forms.Button cellNextBtn;
        private System.Windows.Forms.Button exportDataBtn;
        private System.Windows.Forms.Button saveImageBtn;
        private System.Windows.Forms.Label cursorLabel;
        private System.Windows.Forms.CheckBox showPrevCheckBox;
        private System.Windows.Forms.CheckBox autoCentreCheckBox;
        private System.Windows.Forms.Button loadCSVButton;
        private System.Windows.Forms.TextBox loadCSVTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

