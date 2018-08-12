#!/bin/bash

NUGET_LATEST_DIST="https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
NUGET_DIR=".nuget"
SONARCUBE_DIST="https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/4.3.1.1372/sonar-scanner-msbuild-4.3.1.1372-net46.zip"
SONARCUBE_DIR=".sonarcube"
SONARCUBE_ZIP="${SONARCUBE_DIR}/sonar-scanner-msbuild-4.3.1.1372-net46.zip"
NUGET_PATH="${NUGET_DIR}/nuget.exe"

stop_if_failure()
{
  code="$1"
  process="$2"
  if [ "$code" -ne "0" ]
  then
    echo "The process '${process}' failed with exit code $code"
    exit "$code"
  fi
}

install_latest_nuget()
{
  echo "Downloading the latest version of NuGet ..."

  # Travis uses Xamarin's apt repo which has an ancient nuget version
  mkdir -p "$NUGET_DIR"
  wget -O "$NUGET_PATH" "$NUGET_LATEST_DIST"
  stop_if_failure $? "Download NuGet"
}

install_sonarcube()
{
  echo "Downloading the latest version of Sonar Scanner ..."

  # Travis uses Xamarin's apt repo which has an ancient nuget version
  mkdir -p "$SONARCUBE_DIR"
  wget -O "$SONARCUBE_DIR" "$SONARCUBE_DIST"
  stop_if_failure $? "Download Sonar Scanner"
  
  unzip "$SONARCUBE_ZIP"
}

echo_nuget_version_to_console()
{
  mono "$NUGET_PATH"
}

restore_solution_nuget_packages()
{
  echo "Restoring NuGet packages for the solution ..."
  mono "$NUGET_PATH" restore Agiil.sln
  stop_if_failure $? "Restore NuGet packages"
}

install_npm_packages()
{
  echo "Installing npm packages for the solution ..."
  OLD_DIR="$(pwd)"
  
  cd Agiil.Web/
  npm install
  stop_if_failure $? "Install npm packages to 'Agiil.Web'"
  cd "$OLD_DIR"
}

install_latest_nuget
echo_nuget_version_to_console
restore_solution_nuget_packages
install_npm_packages
install_sonarcube

exit 0