#!/bin/bash

# This script should automatically install .NET Core 2
# on your Debian9 machine. Maybe it needs some fine 
# tunning, so use at your own risk. See attached PDF 
# for Microsoft's official instructions.

# First, download Microsoft keys
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg
sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/

# Add Microsoft's source to apt source list
wget -q https://packages.microsoft.com/config/debian/9/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list

# Install https transport so that https repos can be handled (god 
# bless AskUbuntu.com). 
sudo apt install apt-transport-https

# Set owner of both files to root:root (permission)
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list

#Install SDK from repo (update sources, then install)
sudo apt update
sudo apt install dotnet-sdk-2.1

#Install dotnet runtime (2.1)
sudo apt install dotnet-runtime-2.1

