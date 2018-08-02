using CSF.Screenplay.Integration;
using CSF.Screenplay;
using CSF.Screenplay.WebApis.Abilities;
using CSF.Screenplay.Selenium;
using CSF.Screenplay.Selenium.Abilities;
using System.IO;
using CSF.Screenplay.Selenium.Reporting;
using CSF.Screenplay.SpecFlow;
using System;
using CSF.Screenplay.ReportFormatting;
using CSF.Screenplay.Reporting;

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
          .WithFormattingStrategy<StringCollectionFormattingStrategy>()
          .WithFormattingStrategy<OptionCollectionFormatter>()
          .WithFormattingStrategy<ElementCollectionFormatter>()
          .WithScenarioRenderer(JsonScenarioRenderer.CreateForFile("Agiil.Tests.BDD.report.json"));
      });
      builder.UseSharedUriTransformer(new RootUriPrependingTransformer(ApplicationBaseUri));
      builder.UseWebDriverFromConfiguration();
      builder.UseWebBrowser();
      builder.UseBrowserFlags();
      builder.ServiceRegistrations.PerScenario.Add(helper => {
        helper.RegisterFactory(() => new ConsumeWebServices(new Uri(ApiBaseUri)));
      });
    }
  }
}
