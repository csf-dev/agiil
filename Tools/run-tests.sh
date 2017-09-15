#!/bin/sh

# Short helper script for running all of the unit tests on Linux

SOLUTION_ROOT="$(dirname "$0")/.."
RUNNER_PATH="packages/NUnit.ConsoleRunner.3.6.1/tools/nunit3-console.exe"
TEST_ASSEMBLIES="$(find ./Tests/ -type f -path "*/bin/Debug/*" -name "Agiil.Tests*.dll" \! -name "Agiil.Tests.Common.dll")"

mono "${SOLUTION_ROOT}/${RUNNER_PATH}" --labels="All" $TEST_ASSEMBLIES
