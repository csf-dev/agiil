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
  mono nuget restore Agiil.sln
  stop_if_failure $? "Restore NuGet packages"
}

install_npm_packages()
{
  echo "Installing npm packages for the solution ..."
  npm install Agiil.Web/
  stop_if_failure $? "Install npm packages"
}

install_latest_nuget
echo_nuget_version_to_console
restore_solution_nuget_packages
install_npm_packages

exit 0