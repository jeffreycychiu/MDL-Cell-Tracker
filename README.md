# MDL-Cell-Tracker
Simple program to manuall track cell XY location in a series of images

## Install
- Download **Release** folder from this repository and run **MDL Cell Tracker.exe**
- *Note: Software only works in Windows. Tested on Windows 7, 8 and 10.*

## Using the software
- Run **MDL Cell Tracker.exe**
- Click on the **Image Folder** button on the top left and navigate to the folder containing all of your images. ***Only .bmp file format supported currently*** *(Note: A folder with sample pictures has been included in this repository)*
- **Left Click** on a cell to put down the first tracking point
- Use the **right arrow** and **left arrow** keys to move to the next or previous picture
- **Right click** to remove the tracking point on the current picture
- Click on the **Previous** and **Next** buttons on the top of the program to go to the next or previous cell after one has been tracked.
- After the tracking is complete, click on **Export Data** to export all of the tracked points to a CSV file
- **Save Images** saves the images with the tracked paths overlain

Additional options:
- The **Auto-Centre** checkbox attempts to centre the tracking point to the centroid of the cell using image processing. Uncheck to make the point completely manual (sometimes the auto-centreing will have problems)
- **Show Prev Movement** checkbox - toggle to see the previous tracking points of the previous images in the series. Uncheck to only see the tracking points on the current image in the image series.
- **Load CSV** If you are tracking many cells in a large image series, you may want to periodically save the data using the **Export Data** button. The **Load CSV** button allows you to load back the data exported into the program so no work is lost.
