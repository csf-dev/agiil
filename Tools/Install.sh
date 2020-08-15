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
  
  cd Agiil.Web.Client/
  npm ci
  npm_exit=$?
  cd "$OLD_DIR"
  stop_if_failure $npm_exit "Install npm packages to 'Agiil.Web.Client'"
}

install_test_runner()
{
    nuget install NUnit.ConsoleRunner -Version 3.7.0 -OutputDirectory packages/
}

restore_solution_nuget_packages
install_npm_packages
install_test_runner

exit 0
