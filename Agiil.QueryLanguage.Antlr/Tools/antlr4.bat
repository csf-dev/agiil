SET SCRIPT_PATH=%~dp0
SET ANTLR_JAR_PATH=%SCRIPT_PATH%..\lib

SET CUSTOM_CLASSPATH=.:%ANTLR_JAR_PATH%

java -cp %CUSTOM_CLASSPATH% org.antlr.v4.Tool %*
