#!/bin/bash

NUNIT_CONSOLE_VERSION="3.7.0"
NUNIT_PATH="./packages/NUnit.ConsoleRunner.${NUNIT_CONSOLE_VERSION}/tools/nunit3-console.exe"
WEB_TESTS="Agiil.Tests.BDD.dll"
TEST_SUPPORT="Agiil.Tests.Common.dll"

test_assemblies=$(find ./Tests/ -type f -path "*/bin/**/*" -name "Agiil.Tests.*.dll" \! -name "$WEB_TESTS" \! -name "$TEST_SUPPORT" )
mono "$NUNIT_PATH" \
  --result="Tests/Temp/TestResult.unit-tests.xml" \
  $test_assemblies

exit "$?"
