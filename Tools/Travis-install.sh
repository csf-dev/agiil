#!/bin/bash

NUGET_LATEST_DIST="https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
NUGET_DIR=".nuget"
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

install_latest_npm()
{
  npm install -g npm@latest
}

install_npm_packages()
{
  echo "Installing npm packages for the solution ..."
  OLD_DIR="$(pwd)"
  
  cd Agiil.Web/
  npm ci
  stop_if_failure $? "Install npm packages to 'Agiil.Web'"
  cd "$OLD_DIR"
  
  cd Agiil.Web.Client/
  npm ci
  stop_if_failure $? "Install npm packages to 'Agiil.Web.Client'"
  cd "$OLD_DIR"
}

setup_megarc_file()
{
  echo "[Login]
Username = ${MEGA_USERNAME}
Password = ${MEGA_PASSWORD}
" > ~/.megarc
}

install_latest_nuget
echo_nuget_version_to_console
restore_solution_nuget_packages
install_latest_npm
install_npm_packages
setup_megarc_file

exit 0
