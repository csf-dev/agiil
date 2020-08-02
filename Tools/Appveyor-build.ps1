Set-PSDebug -Trace 1

$BuildNumber = $Env:APPVEYOR_BUILD_NUMBER
$SonarCloudKey = $Env:SONARCLOUD_SECRET_KEY
$BuildPath = $Env:APPVEYOR_BUILD_FOLDER
$OpenCoverInstallDir = ($BuildPath + '\.OpenCover')
$OpenCoverRunnerPath = ($OpenCoverInstallDir + '\OpenCover.' + $Env:opencover_version + '\tools\OpenCover.Console.exe')
$NUnitInstallDir = ($BuildPath + '\.NUnit')
$NUnitRunnerPath = ($NUnitInstallDir + '\NUnit.ConsoleRunner.' + $Env:nunit_console_version + '\tools\nunit3-console.exe')
$OpenCoverOutputFile = ($BuildPath + '\OpenCover.xml')

SonarScanner.MSBuild.exe begin `
    /k:"Agiil" `
    /v:AppVeyor_build_$BuildNumber `
    /s:$BuildNumber\.sonarqube-analysisproperties.xml `
    /o:craigfowler-github `
    /d:sonar.host.url="https://sonarcloud.io" `
    /d:sonar.login=$SonarCloudKey `
    /d:sonar.cs.nunit.reportsPaths=$BuildPath\Tests\Temp\TestResult.unit-tests.xml `
    /d:sonar.cs.opencover.reportsPaths=$BuildPath\OpenCover.xml
  
msbuild `
    /verbosity:normal `
    /p:Configuration=AppVeyorCI `
    "Agiil.sln" 

$TestResultPath = ($BuildPath + 'Tests\Temp\TestResult.unit-tests.xml')
$AuthTests = 'Tests\Agiil.Tests.Auth\bin\Debug\net471\Agiil.Tests.Auth.dll'
$DataTests = 'Tests\Agiil.Tests.Data\bin\Debug\net471\Agiil.Tests.Data.dll'
$DomainTests = 'Tests\Agiil.Tests.Domain\bin\Debug\net471\Agiil.Tests.Domain.dll'
$WebTests = 'Tests\Agiil.Tests.Web\bin\Debug\net471\Agiil.Tests.Web.dll'

&$OpenCoverRunnerPath `
    -register:Path64 `
    -target:$NUnitRunnerPath `
    -targetargs:"--result=$TestResultPath $AuthTests $DataTests $DomainTests $WebTests" `
    -output:$OpenCoverOutputFile `
    -filter:"+[Agiil.*]* -[Agiil.Tests.*]* -[Agiil.BDD]* -[Agiil.Web.TestBuild]* -[Agiil.Web.Client]* -[Agiil.QueryLanguage.Antlr]* -[Agiil.Bootstrap]* -[Agiil.Web.Models]*" `
    -returntargetcode

$FinalExitCode = $LASTEXITCODE

SonarScanner.MSBuild.exe end `
    /d:sonar.login=$SonarCloudKey

Push-AppveyorArtifact OpenCover.xml
Get-ChildItem Tests\**\TestResult.unit-tests.xml | ForEach-Object { Push-AppveyorArtifact $_.FullName -FileName $_.Name }
Get-ChildItem Tests\**\*.db | ForEach-Object { Push-AppveyorArtifact $_.FullName -FileName $_.Name }
Get-ChildItem Tests\**\.log | ForEach-Object { Push-AppveyorArtifact $_.FullName -FileName $_.Name }

exit $FinalExitCode
