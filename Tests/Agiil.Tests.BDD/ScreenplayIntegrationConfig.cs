using System;
using CSF.Screenplay.Integration;
using CSF.Screenplay;
using CSF.Screenplay.Web;
using CSF.Screenplay.Reporting.Models;
using CSF.Screenplay.Reporting;
using CSF.Screenplay.Web.Abilities;
using OpenQA.Selenium;
using CSF.WebDriverFactory;
using System.IO;

namespace Agiil.Tests.BDD
{
  public class ScreenplayIntegrationConfig : IIntegrationConfig
  {
    public void Configure(IIntegrationConfigBuilder builder)
    {
      builder.UseCast();
      builder.UseReporting(reporting => {
        reporting
          .SubscribeToActorsCreatedInCast()
          .WriteReport(WriteReport);
      });
      builder.UseUriTransformer(new RootUriPrependingTransformer("http://localhost:8080/"));
      builder.UseWebDriver(GetWebDriver);
      builder.UseWebBrowser();
    }

    void WriteReport(Report report)
    {
      var directory = TestFilesystem.GetTestTemporaryDirectory();
      var reportPath = Path.Combine(directory.FullName, $"Agiil.Tests.BDD.report.txt");
      TextReportWriter.WriteToFile(report, reportPath);
    }

    IWebDriver GetWebDriver()
    {
      var provider = new ConfigurationWebDriverFactoryProvider();
      var factory = provider.GetFactory();
      return factory.GetWebDriver();
    }
  }
}
