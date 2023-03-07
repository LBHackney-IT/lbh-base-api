#!/bin/bash

#install zip on debian OS, since microsoft/dotnet container doesn't have zip by default
if [ -f /etc/debian_version ]
then
  apt -qq update
  apt -qq -y install zip
fi

#dotnet restore
dotnet tool install --global Amazon.Lambda.Tools --version 4.0.0


# (for CI) ensure that the newly-installed tools are on PATH
if [ -f /etc/debian_version ]
then
  export PATH="$PATH:/$(whoami)/.dotnet/tools"
fi

dotnet restore
dotnet lambda package --configuration release --framework net6.0 --output-package ./bin/release/net6.0/base-api.zip
