#!/bin/bash
 
SCRIPT_DIR="$(dirname "$0")"
WEB_TESTS_PATH="${SCRIPT_DIR}/../Tests/Agiil.Tests.BDD/bin/TravisCI/net471/Agiil.Tests.BDD.dll"

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
  ${SCRIPT_DIR}/Run-unit-tests.sh
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
  export WEB_TESTS_PATH
  ${SCRIPT_DIR}/Run-integration-tests.sh
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
