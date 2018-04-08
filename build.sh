#!/usr/bin/env bash
dotnet restore && dotnet build /p:Configuration=Release /p:Platform="Any CPU" -f netcoreapp2.0