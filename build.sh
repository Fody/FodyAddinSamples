#!/usr/bin/env bash
dotnet restore && dotnet build /p:Configuration=Release /p:Platform="Any CPU"