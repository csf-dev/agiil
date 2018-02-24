using System;
using CSF.Screenplay.Integration;
using CSF.Screenplay;
using CSF.Screenplay.Selenium;
using CSF.Screenplay.Reporting.Models;
using CSF.Screenplay.Reporting;
using CSF.Screenplay.Selenium.Abilities;
using OpenQA.Selenium;
using System.IO;
using CSF.Screenplay.Scenarios;
using System.Collections.Generic;
using CSF.Screenplay.Selenium.Reporting;

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
          .WithFormatter<StringArrayFormatter>()
          .WithFormatter<OptionCollectionFormatter>()
          .WithFormatter<ElementCollectionFormatter>()
          .WriteReport(WriteReport);
      });
      builder.UseSharedUriTransformer(new RootUriPrependingTransformer("http://localhost:8080/"));
      builder.UseWebDriverFromConfiguration();
      builder.UseWebBrowser();
    }

    void WriteReport(IObjectFormattingService formatter, Report report)
    {
      var directory = TestFilesystem.GetTestTemporaryDirectory();
      var reportPath = Path.Combine(directory.FullName, $"Agiil.Tests.BDD.report.txt");
      TextReportWriter.WriteToFile(report, reportPath, formatter);
    }
  }
}
