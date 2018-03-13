#!/bin/bash

NUNIT_CONSOLE_VERSION="3.7.0"
NUNIT_PATH="./packages/NUnit.ConsoleRunner.${NUNIT_CONSOLE_VERSION}/tools/nunit3-console.exe"
TEST_HOME="./Tests"
WEB_TESTS_PATH="${TEST_HOME}/Agiil.Tests.BDD/bin/Debug/Agiil.Tests.BDD.dll"
SCRIPT_DIR="$(dirname "$0")"
WEB_APP_HOME="Agiil.Web"
WEB_APP_BIN="${WEB_APP_HOME}/bin"
TESTING_BIN="Tests/Agiil.Web.TestBuild/bin/Debug"

test_outcome=1

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

prepare_webapp_for_testing()
{
  echo "Configuring Agiil for BDD tests ..."
  cp "$TESTING_BIN"/* "${WEB_APP_BIN}/"
}

start_webserver()
{
  echo "Starting up the application ..."
  bash "$SCRIPT_DIR/Start-webserver.sh"
  stop_if_failure $? "Starting the application"
}

run_the_tests()
{
  echo "Running integration tests ..."
  mono "$NUNIT_PATH" --labels=All "$WEB_TESTS_PATH"
  test_outcome=$?
}

shutdown_webserver()
{
  bash "$SCRIPT_DIR/Stop-webserver.sh"
}

prepare_webapp_for_testing
start_webserver
run_the_tests
shutdown_webserver

exit $test_outcome