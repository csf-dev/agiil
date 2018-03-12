#!/bin/bash

NUNIT_CONSOLE_VERSION="3.7.0"
NUNIT_PATH="./testrunner/NUnit.ConsoleRunner.${NUNIT_CONSOLE_VERSION}/tools/nunit3-console.exe"
TEST_PATTERN="Agiil.Tests.*.dll"
WEB_TESTS="Agiil.Tests.BDD.dll"
TEST_SUPPORT="Agiil.Tests.Common.dll"

test_assemblies=$(find ./Tests/ -type f -path "*/bin/Debug/*" -name "$TEST_PATTERN" \! -name "$WEB_TESTS" \! -name "$TEST_SUPPORT" )
mono "$NUNIT_PATH" $test_assemblies

exit "$?"