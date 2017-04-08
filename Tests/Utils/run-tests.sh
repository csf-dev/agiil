#!/bin/sh

SOLUTION_ROOT="$(dirname "$0")/../.."
RUNNER_PATH="packages/NUnit.Console.3.0.0/tools/nunit3-console.exe"
TEST_ASSEMBLIES="$(find ./Tests/ -type f -path "*/bin/Debug/*" -name "Agiil.Tests*.dll" \! -name "Agiil.Tests.Common.dll")"

mono "${SOLUTION_ROOT}/${RUNNER_PATH}" $TEST_ASSEMBLIES