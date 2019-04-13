#!/bin/bash
 
NUNIT_CONSOLE_VERSION="3.7.0"
NUNIT_PATH="./packages/NUnit.ConsoleRunner.${NUNIT_CONSOLE_VERSION}/tools/nunit3-console.exe"
TEST_PATTERN="Agiil.Tests.*.dll"
WEB_TESTS="Agiil.Tests.BDD.dll"
TEST_SUPPORT="Agiil.Tests.Common.dll"
SCRIPT_DIR="$(dirname "$0")"
WEBSERVER_PID=".xsp4.pid"
TEST_HOME="./Tests"
WEB_TESTS_PATH="${TEST_HOME}/Agiil.Tests.BDD/bin/Debug/Agiil.Tests.BDD.dll"
TEST_TEMP_DIR="${TEST_HOME}/Temp"
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
  msbuild /p:Configuration=TravisCI Agiil.sln

  stop_if_failure $? "Build the solution"
}

run_unit_tests()
{
  echo "Running unit tests ..."
  Tools/Run-unit-tests.sh
  stop_if_failure $? "Run unit tests"
}

prepare_screenplay_env_variables()
{
  WebDriver_SauceLabsBuildName="Travis Agiil job ${TRAVIS_JOB_NUMBER}; ${WebDriver_BrowserName}"
  WebDriver_TunnelIdentifier="$TRAVIS_JOB_NUMBER"
  export WebDriver_SauceLabsBuildName
  export WebDriver_TunnelIdentifier
}

run_integration_tests()
{
  Tools/Run-integration-tests.sh
  test_outcome=$?
}

upload_artifacts()
{
  TRAVIS_SUBFOLDER="Travis-${TRAVIS_JOB_NUMBER}"
  ARTIFACTS_DIR="/Root/BuildArtifacts/${TRAVIS_SUBFOLDER}"
  megamkdir "$ARTIFACTS_DIR"
  megaput --no-progress --path "${ARTIFACTS_DIR}/TestResult.unit-tests.xml" "Tests/Temp/TestResult.unit-tests.xml"
  megaput --no-progress --path "${ARTIFACTS_DIR}/TestResult.bdd-tests.xml" "Tests/Temp/TestResult.bdd-tests.xml"
  megaput --no-progress --path "${ARTIFACTS_DIR}/Agiil.Tests.BDD.report.json" "Agiil.Tests.BDD.report.json"
  megaput --no-progress --path "${ARTIFACTS_DIR}/Agiil.Web.log" "Output/Web apps/Agiil.Web/Agiil.Web.log"
}

build_solution
run_unit_tests
prepare_screenplay_env_variables
run_integration_tests
upload_artifacts

exit $test_outcome
