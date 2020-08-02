git submodule update --init --recursive

Install-Product node $Env:nodejs_version
choco install "sonarscanner-msbuild-net46" -y

$OpenCoverInstallDir = ($Env:APPVEYOR_BUILD_FOLDER + '\.OpenCover')
nuget install -OutputDirectory $OpenCoverInstallDir -Version $Env:opencover_version OpenCover

$NUnitInstallDir = ($Env:APPVEYOR_BUILD_FOLDER + '\.NUnit')
nuget install -OutputDirectory $NUnitInstallDir -Version $Env:nunit_console_version NUnit.ConsoleRunner

nuget restore Agiil.sln

npm install -g npm@latest

Set-Location Agiil.Web.Client
npm ci
Set-Location ..
