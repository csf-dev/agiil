@echo on

git submodule update --init --recursive

cd Agiil.Web
npm install
cd ..

nuget restore Agiil.sln