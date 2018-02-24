using CSF.Screenplay.Integration;
using CSF.Screenplay;
using CSF.Screenplay.JsonApis.Abilities;
using CSF.Screenplay.Selenium;
using CSF.Screenplay.Reporting.Models;
using CSF.Screenplay.Reporting;
using CSF.Screenplay.Selenium.Abilities;
using System.IO;
using CSF.Screenplay.Selenium.Reporting;
using CSF.Screenplay.SpecFlow;

[assembly: ScreenplayAssembly(typeof(Agiil.Tests.BDD.ScreenplayIntegrationConfig))]

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
      builder.UseBrowserFlags();
      builder.ServiceRegistrations.PerScenario.Add(helper => {
        helper.RegisterFactory(() => new ConsumeJsonWebServices("http://localhost:8080/api/v1/"));
      });
    }

    void WriteReport(IObjectFormattingService formatter, Report report)
    {
      var directory = TestFilesystem.GetTestTemporaryDirectory();
      var reportPath = Path.Combine(directory.FullName, $"Agiil.Tests.BDD.report.txt");
      TextReportWriter.WriteToFile(report, reportPath, formatter);
    }
  }
}
