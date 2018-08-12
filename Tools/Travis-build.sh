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
SONARCUBE_DIR=".sonarcube"
SONARCUBE_TOOL="${SONARCUBE_DIR}/SonarScanner.MSBuild.exe"

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

run_sonarcube_static_code_analysis()
{
  if [ "$Analyse_With_SonarCube" == "Yes" ]
  then
    echo "Beginning SonarCube static code analysis ..."
    
    version_number="Travis_job_$TRAVIS_JOB_NUMBER"
    anlysis_properties_file="$(pwd)/.sonarqube-analysisproperties.xml"
    
    mono "$SONARCUBE_TOOL" begin \
      /k:"Agiil" \
      /v:"$version_number" \
      /s:"$anlysis_properties_file" \
      /d:sonar.organization="craigfowler-github" \
      /d:sonar.host.url="https://sonarcloud.io" \
      /d:sonar.login="$SONARCLOUD_SECRET_KEY"
    
    echo "Rebuilding for static code analysis ..."
    
    msbuild /t:Rebuild /nologo /verbosity:quiet
    
    echo "Completing SonarCube static code analysis ..."
    
    mono "$SONARCUBE_TOOL" end \
      /d:sonar.login="$SONARCLOUD_SECRET_KEY"
  else
    echo "Skipping SonarCube static code analysis because environment variable 'Analyse_With_SonarCube' is not 'Yes'"
  fi
}

run_integration_tests()
{
  Tools/Run-integration-tests.sh
  test_outcome=$?
}

build_solution
run_unit_tests
prepare_screenplay_env_variables
run_integration_tests
run_sonarcube_static_code_analysis

exit $test_outcome
