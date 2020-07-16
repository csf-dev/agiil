#!/bin/bash

NUNIT_CONSOLE_VERSION="3.7.0"
NUNIT_PATH="./packages/NUnit.ConsoleRunner.${NUNIT_CONSOLE_VERSION}/tools/nunit3-console.exe"
WEB_TESTS_PATH="${WEB_TESTS_PATH:-./Tests/Agiil.Tests.BDD/bin/Debug/net471/Agiil.Tests.BDD.dll}"
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
  mono "$NUNIT_PATH" \
    --labels=All \
    --result="Tests/Temp/TestResult.bdd-tests.xml" \
    "$WEB_TESTS_PATH"
  test_outcome=$?
}

shutdown_webserver()
{
  bash "$SCRIPT_DIR/Stop-webserver.sh"
}

convert_test_results()
{
  nuget install -OutputDirectory packages -Version 1.0.0 CSF.Screenplay.Reporting.JsonToHtml
  ./packages/CSF.Screenplay.Reporting.JsonToHtml.1.0.0/tools/CSF.Screenplay.Reporting.JsonToHtml.exe \
    Agiil.Tests.BDD.report.json \
    Agiil.Tests.BDD.report.html
}

start_webserver
run_the_tests
shutdown_webserver
convert_test_results

exit $test_outcome
