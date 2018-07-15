#!/bin/bash
SCRIPT_PATH="$(dirname "$(readlink -f "$0")")"
ANTLR_JAR_PATH="${SCRIPT_PATH}/../lib"
CUSTOM_CLASSPATH=".:${ANTLR_JAR_PATH}/antlr-4.7.1-complete.jar:$CLASSPATH"

target_path="$1"

javac -cp "$CUSTOM_CLASSPATH" "$target_path"/*.java