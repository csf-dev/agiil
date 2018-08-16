﻿using Agiil.BDD.Abilities;
using CSF.Screenplay;
using CSF.Screenplay.Integration;
using CSF.Screenplay.ReportFormatting;
using CSF.Screenplay.Reporting;
using CSF.Screenplay.Selenium;
using CSF.Screenplay.Selenium.Abilities;
using CSF.Screenplay.Selenium.Reporting;
using CSF.Screenplay.SpecFlow;
using CSF.Screenplay.WebApis;

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
      builder.UseSharedUriTransformer(new RootUriPrependingTransformer(ApplicationBaseUri));
      builder.UseWebDriverFromConfiguration();
      builder.UseWebBrowser();
      builder.UseBrowserFlags();
      builder.UseWebApis(ApiBaseUri);
      builder.UseAutofacContainer();

      ConfigureReporting(builder);
    }

    void ConfigureReporting(IIntegrationConfigBuilder builder)
    {
      builder.UseReporting(reporting => {
        reporting
          .SubscribeToActorsCreatedInCast()
          .WithFormattingStrategy<StringCollectionFormattingStrategy>()
          .WithFormattingStrategy<OptionCollectionFormatter>()
          .WithFormattingStrategy<ElementCollectionFormatter>()
          .WithScenarioRenderer(JsonScenarioRenderer.CreateForFile("Agiil.Tests.BDD.report.json"));
      });
    }
  }
}
