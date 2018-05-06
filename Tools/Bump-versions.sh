#!/bin/bash

SOLUTION_ROOT="$(dirname $0)/.."
NEW_VERSION="$1"
ASSEMBLY_VERSION="$(echo "$NEW_VERSION" | egrep -o "([0-9]+\.){2}[0-9]+").0"

function bump_assembly_info()
{
  find "$SOLUTION_ROOT" \
    \! -path "*/.git/*" \
    -name "AssemblyInfo.cs" \
    -exec sed -ri "s/AssemblyVersion\\(\"([0-9]+\\.){0,3}[0-9]+\"\\)/AssemblyVersion(\"${ASSEMBLY_VERSION}\")/g" '{}' \;
    
  find "$SOLUTION_ROOT" \
    \! -path "*/.git/*" \
    -name "AssemblyInfo.cs" \
    -exec sed -ri "s/AssemblyInformationalVersion\\(\"[^\"]+\"\\)/AssemblyInformationalVersion(\"${NEW_VERSION}\")/g" '{}' \;
}

function bump_solution_version()
{
  SOLUTION_FILE="$SOLUTION_ROOT/Agiil.sln"
  sed -ri "s/version *= *.+/version = ${NEW_VERSION}/g" "$SOLUTION_FILE"
  
  find "$SOLUTION_ROOT" \
    \! -path "*/.git/*" \
    -name "*.csproj" \
    -exec sed -ri "s/<ReleaseVersion>[^<]+<\\/ReleaseVersion>/<ReleaseVersion>${NEW_VERSION}<\\/ReleaseVersion>/g" '{}' \;
}

function bump_package_json_version()
{
  PACKAGE_JSON_FILE="$SOLUTION_ROOT/package.json"
  sed -ri "s/\"version\" *: *\"[^\"]+\"/\"version\": \"${NEW_VERSION}\"" "$PACKAGE_JSON_FILE"
}

bump_assembly_info
bump_solution_version