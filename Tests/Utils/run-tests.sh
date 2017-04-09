#!/bin/sh

SOLUTION_ROOT="$(dirname "$0")/../.."
RUNNER_PATH="packages/NUnit.ConsoleRunner.3.6.1/tools/nunit3-console.exe"
TEST_ASSEMBLIES="$(find ./Tests/ -type f -path "*/bin/Debug/*" -name "Agiil.Tests*.dll" \! -name "Agiil.Tests.Common.dll")"

mono --debug "${SOLUTION_ROOT}/${RUNNER_PATH}" --inprocess $TEST_ASSEMBLIES