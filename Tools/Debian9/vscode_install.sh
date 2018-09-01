#!/bin/bash

#This script should install visual studio code 
#automatically in your debian-based machine

#Get vscode package from microsoft's website
echo "Downloading VSCode from Microsoft's website. It may take a few minutes..."
wget -q https://go.microsoft.com/fwlink/?LinkID=760868

#Install VSCode
echo "Installing..."
mv index.html?LinkID=760868 vsinst.deb
sudo dpkg -i vsinst.deb
sudo apt install -f
rm -rf vsinst.deb

#done!
echo "Run '$code' to launch VSCode from the terminal."