using CSF.Screenplay.Integration;
using CSF.Screenplay;
using CSF.Screenplay.WebApis.Abilities;
using CSF.Screenplay.Selenium;
using CSF.Screenplay.Reporting.Models;
using CSF.Screenplay.Reporting;
using CSF.Screenplay.Selenium.Abilities;
using System.IO;
using CSF.Screenplay.Selenium.Reporting;
using CSF.Screenplay.SpecFlow;
using System;

[assembly: ScreenplayAssembly(typeof(Agiil.Tests.BDD.ScreenplayIntegrationConfig))]

namespace Agiil.Tests.BDD
{
  public class ScreenplayIntegrationConfig : IIntegrationConfig
  {
    const string
      ApplicationBaseUri = "http://localhost:8080/",
      ApiBaseUri = ApplicationBaseUri + "api/v1/";

    public void Configure(IIntegrationConfigBuilder builder)
    {
      builder.UseCast();
      builder.UseStage();
      builder.UseReporting(reporting => {
        reporting
          .SubscribeToActorsCreatedInCast()
          .WithFormatter<StringArrayFormatter>()
          .WithFormatter<OptionCollectionFormatter>()
          .WithFormatter<ElementCollectionFormatter>()
          .WriteReport(WriteReport);
      });
      builder.UseSharedUriTransformer(new RootUriPrependingTransformer(ApplicationBaseUri));
      builder.UseWebDriverFromConfiguration();
      builder.UseWebBrowser();
      builder.UseBrowserFlags();
      builder.ServiceRegistrations.PerScenario.Add(helper => {
        
        helper.RegisterFactory(() => new ConsumeWebServices(new Uri(ApiBaseUri)));
      });
    }

    void WriteReport(IObjectFormattingService formatter, Report report)
    {
      var directory = TestFilesystem.GetTestTemporaryDirectory();
      WriteTextReport(formatter, report, directory);
      //WriteHtmlReport(formatter, report, directory);
    }

    void WriteTextReport(IObjectFormattingService formatter, Report report, DirectoryInfo directory)
    {
      var reportPath = Path.Combine(directory.FullName, $"Agiil.Tests.BDD.report.txt");
      TextReportWriter.WriteToFile(report, reportPath, formatter);
    }

    void WriteHtmlReport(IObjectFormattingService formatter, Report report, DirectoryInfo directory)
    {
      var reportPath = Path.Combine(directory.FullName, $"Agiil.Tests.BDD.report.html");
      try
      {
        using(var writer = new StreamWriter(reportPath))
        {
          var reportWriter = new HtmlReportWriter(writer, formatter);
          reportWriter.Write(report);
        }
      }
      catch(Exception ex)
      {
        Console.Error.WriteLine("Error whilst writing HTML report");
        Console.Error.WriteLine(ex);
        throw;
      }
    }
  }
}
