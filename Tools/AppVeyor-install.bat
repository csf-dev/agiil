@echo on

git submodule update --init --recursive

nuget restore Agiil.sln

cd Agiil.Web

REM It's very strange but this has to be the last line of the script.
REM As soon as it completes, this script is terminated and nothing afterwards
REM is executed.
npm install
