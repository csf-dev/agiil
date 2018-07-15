#!/bin/bash
SCRIPT_PATH="$(dirname "$(readlink -f "$0")")"
ANTLR_JAR_PATH="${SCRIPT_PATH}/../lib"
CUSTOM_CLASSPATH=".:${ANTLR_JAR_PATH}/antlr-4.7.1-complete.jar:$CLASSPATH"
SOURCE_PATH="${SCRIPT_PATH}/../Grammar"

javac -cp "$CUSTOM_CLASSPATH" "$SOURCE_PATH"/*.java