#!/bin/bash

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

restore_solution_nuget_packages()
{
  echo "Restoring NuGet packages for the solution ..."
  nuget restore Agiil.sln
  stop_if_failure $? "Restore NuGet packages"
}

install_npm_packages()
{
  echo "Installing npm packages for the solution ..."
  OLD_DIR="$(pwd)"
  
  cd Agiil.Web/
  npm install
  npm_exit=$?
  cd "$OLD_DIR"
  stop_if_failure $npm_exit "Install npm packages to 'Agiil.Web'"
  
  cd Agiil.Web.Client/
  npm install
  npm_exit=$?
  cd "$OLD_DIR"
  stop_if_failure $npm_exit "Install npm packages to 'Agiil.Web.Client'"
}

restore_solution_nuget_packages
install_npm_packages

exit 0
