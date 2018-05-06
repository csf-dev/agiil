@echo on

git submodule update --init --recursive
nuget restore Agiil.sln
