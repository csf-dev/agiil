#!/bin/bash
 
NUNIT_CONSOLE_VERSION="3.7.0"
NUNIT_PATH="./testrunner/NUnit.ConsoleRunner.${NUNIT_CONSOLE_VERSION}/tools/nunit3-console.exe"
TEST_PATTERN="Agiil.Tests.*.dll"
WEB_TESTS="Agiil.Tests.BDD.dll"
TEST_SUPPORT="Agiil.Tests.Common.dll"
SCRIPT_DIR="$(dirname "$0")"
WEBSERVER_PID=".xsp4.pid"
TEST_HOME="./Tests"
WEB_TESTS_PATH="${TEST_HOME}/Agiil.Tests.BDD/bin/Debug/Agiil.Tests.BDD.dll"
TEST_TEMP_DIR="${TEST_HOME}/Temp"
BDD_REPORT_PATH="${TEST_TEMP_DIR}/Agiil.Tests.BDD.report.txt"
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

build_solution()
{
  echo "Building the solution ..."
  msbuild /p:Configuration=Debug Agiil.sln

  stop_if_failure $? "Build the solution"
}

run_unit_tests()
{
  echo "Running unit tests ..."
  Tools/Run-unit-tests.sh
  stop_if_failure $? "Run unit tests"
}

prepare_webapp_for_testing()
{
  echo "Configuring Agiil for BDD tests ..."
  cp "$TESTING_BIN"/* "${WEB_APP_BIN}/"
  cp "${TEST_HOME}/Agiil.Tests.BDD/App.Travis.config" "${WEB_TESTS_PATH}.config"
  cp "${WEB_APP_HOME}/Web.Travis.config" "${WEB_APP_HOME}/Web.config"
}

start_webserver()
{
  echo "Starting up the application ..."
  bash "$SCRIPT_DIR/Start-webserver.sh"
  stop_if_failure $? "Starting the application"
}

run_integration_tests()
{
  echo "Running integration tests ..."
  mono "$NUNIT_PATH" --labels=All "$WEB_TESTS_PATH"
  test_outcome=$?
}

shutdown_webserver()
{
  bash "$SCRIPT_DIR/Stop-webserver.sh"
}

echo_integration_test_results_to_console()
{
  cat "$BDD_REPORT_PATH"
}

build_solution
run_unit_tests
prepare_webapp_for_testing
start_webserver
run_integration_tests
echo_integration_test_results_to_console
shutdown_webserver

exit $test_outcome
