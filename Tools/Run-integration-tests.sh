#!/bin/bash

NUNIT_CONSOLE_VERSION="3.7.0"
NUNIT_PATH="./packages/NUnit.ConsoleRunner.${NUNIT_CONSOLE_VERSION}/tools/nunit3-console.exe"
TEST_HOME="./Tests"
WEB_TESTS_PATH="${TEST_HOME}/Agiil.Tests.BDD/bin/Debug/Agiil.Tests.BDD.dll"
SCRIPT_DIR="$(dirname "$0")"

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

start_webserver
run_the_tests
shutdown_webserver

exit $test_outcome