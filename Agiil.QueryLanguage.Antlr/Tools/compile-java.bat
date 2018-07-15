SET SCRIPT_PATH=%~dp0
SET ANTLR_JAR_PATH=%SCRIPT_PATH%..\lib
SET CUSTOM_CLASSPATH=.:%ANTLR_JAR_PATH%\antlr-4.7.1-complete.jar:%CLASSPATH%

target_path=%1

javac -cp %CUSTOM_CLASSPATH% %target_path%\*.java