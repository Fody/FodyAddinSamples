#!/usr/bin/env bash
dotnet restore && dotnet build /p:Configuration=ReleaseNetCore /p:Platform="Any CPU" /f:netcoreapp2.0