SET ANTLR_JAR_PATH=lib\*.jar
SET CLASSPATH=%ANTLR_JAR_PATH%

java org.antlr.v4.Tool %*
