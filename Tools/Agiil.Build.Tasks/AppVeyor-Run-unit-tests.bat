%APPVEYOR_BUILD_FOLDER%\packages\NUnit.ConsoleRunner.3.7.0\tools\nunit3-console.exe ^
  --result=%APPVEYOR_BUILD_FOLDER%\Tests\Temp\TestResult.unit-tests.xml ^
  --result=%APPVEYOR_BUILD_FOLDER%\Tests\Temp\TestResult.unit-tests.AppVeyor.xml;format=AppVeyor ^
  Tests\Agiil.Tests.Auth\bin\Debug\Agiil.Tests.Auth.dll ^
  Tests\Agiil.Tests.Data\bin\Debug\Agiil.Tests.Data.dll ^
  Tests\Agiil.Tests.Domain\bin\Debug\Agiil.Tests.Services.dll ^
  Tests\Agiil.Tests.Web\bin\Debug\Agiil.Tests.Web.dll