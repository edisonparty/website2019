#!/usr/bin/env bash
#
# Copyright (c) .NET Foundation and contributors. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for full license information.
#
set -e


artifactsfolder="./artifacts"
if [ -d $artifactsfolder ]; then
  rm -R $artifactsfolder
fi

dotnet restore

dotnet build -c Release

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision) 

dotnet pack ./web/web.csproj -c Release -o ./artifacts --version-suffix=$revision 