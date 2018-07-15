#!/bin/bash
SCRIPT_PATH="$(dirname "$(readlink -f "$0")")"
ANTLR_JAR_PATH="${SCRIPT_PATH}/../lib"
CUSTOM_CLASSPATH=".:${ANTLR_JAR_PATH}/antlr-4.7.1-complete.jar:$CLASSPATH"

java -cp "$CUSTOM_CLASSPATH" org.antlr.v4.gui.TestRig $*