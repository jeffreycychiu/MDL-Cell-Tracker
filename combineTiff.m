%This m-file takes all of the tiff files with separate channels and
%combines them into one channel with multiple images.
%It is intended for use of the files converted to TIFF from CZI files
%created by the Zeiss software.

%INPUT: Requires specific folder structure. Parent folder should contain
%this m-file. Each subfolder should contain ONLY the .TIFF files from each
%time point, each channel with as a different file where the intended
%channel to be kept is stored in channel 2 specifically (Yes, this is a 
%very specific and weird format. Don't blame me if it doesn't work in 
%the future  ¯\_(?)_/¯ )

%OUTPUT: New folder containing one image for each time point. Image formats 
%of the new images are proper multichannel tiff format.

%Written by Jeffrey Chiu, 2018-10-04
clear all

EXTRACT_CHANNEL = 2; %This is the channel you are extracting from. Change this if you change however the zeiss software worked, I don't know

% Determine where your m-file's folder is.
folder = fileparts(which(mfilename)); 
% Add that folder plus all subfolders to the path.
addpath(genpath(folder));

% Get a list of all files and folders in this folder.
files = dir(folder);
% Get a logical vector that tells whcleich is a directory.
dirFlags = [files.isdir];
% Extract only those that are directories.
subFolders = files(dirFlags);
%for each subfolder in the directory, create a new TIFF image that each
%channel is channel 2 of the individual TIFF images.
newCombinedImages = cell(1,length(subFolders)-2);
for i = 1 : length(subFolders)
	%fprintf('Sub folder #%d = %s\n', k, subFolders(k).name);
    if subFolders(i).name == "." || subFolders(i).name == ".."
        %do nothing
    else
        subFolderPath = strcat(folder,"\", subFolders(i).name);
        cd(subFolderPath);
        subFolderFiles = dir(fullfile(subFolderPath, '*.tif'));
        images = cell(1,length(subFolderFiles));
        channels = cell(1,length(subFolderFiles));
        for j = 1 : length(subFolderFiles)
            images{j} = imread(subFolderFiles(j).name);
            channels{j} = images{j}(:,:,EXTRACT_CHANNEL); %Extract the defined channel from each file
        end
        
        %Combine all the channels in "channels" into one tiff image
        newImage = zeros(size(channels{j},1), size(channels{j},2), length(subFolderFiles),'uint8');
        for k = 1 : length(channels)
            newImage(:,:,k) = channels{k};
        end
        newCombinedImages{i} = newImage;
    end
end

%Save each of the newly generated combined images into the parent folder
cd(folder)

for i = 1 : length(newCombinedImages)
    if subFolders(i).name == "." || subFolders(i).name == ".."
        %do nothing
    else
        newFileName = strcat(subFolders(i).name,'.tif');
        %old: write combined multi channel image into new tiff
        %imwrite(newCombinedImages{i}, newFileName, 'tif');
        
        %new: write it as a multi-page tiff
        imwrite(newCombinedImages{i}(:,:,1), newFileName, 'tif');
        for p = 2 : size(newCombinedImages{i},3)
            imwrite(newCombinedImages{i}(:,:,p), newFileName, 'tif', 'writemode', 'append');
        end
    end
end

