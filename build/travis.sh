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
echo "RESTORING PACKAGES FOR SOLUTION"

dotnet restore web.sln

echo "BUILDING SOLUTION"

dotnet build web.sln -c Release

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision) 

echo "PACKING WEB PROJECT"

dotnet pack ./web/web.csproj -c Release -o ./artifacts --version-suffix=$revision 

echo "SCRIPT EXECUTION DONE"

ls -la $artifactsfolder