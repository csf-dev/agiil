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
using CSF.Screenplay.Scenarios;
using System.Collections.Generic;
using CSF.Screenplay.Web.Reporting;

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
      builder.UseUriTransformer(new RootUriPrependingTransformer("http://localhost:8080/"));
      builder.UseWebDriver(GetWebDriver);
      builder.UseWebBrowser();
    }

    void WriteReport(IObjectFormattingService formatter, Report report)
    {
      var directory = TestFilesystem.GetTestTemporaryDirectory();
      var reportPath = Path.Combine(directory.FullName, $"Agiil.Tests.BDD.report.txt");
      TextReportWriter.WriteToFile(report, reportPath, formatter);
    }

    IWebDriver GetWebDriver(IServiceResolver resolver)
    {
      var provider = new ConfigurationWebDriverFactoryProvider();
      var factory = provider.GetFactory();

      var caps = new Dictionary<string,object>();

      if(factory is SauceConnectWebDriverFactory)
      {
        caps.Add(SauceConnectWebDriverFactory.TestNameCapability, GetTestName(resolver));
      }

      return factory.GetWebDriver(caps);
    }

    BrowseTheWeb GetWebBrowser(IServiceResolver scenario)
    {
      var provider = new ConfigurationWebDriverFactoryProvider();
      var factory = provider.GetFactory();

      var driver = scenario.GetService<IWebDriver>();
      var transformer = scenario.GetOptionalService<IUriTransformer>();
      var ability = new BrowseTheWeb(driver, transformer?? NoOpUriTransformer.Default);

      ConfigureBrowserCapabilities(ability, factory);

      return ability;
    }

    void ConfigureBrowserCapabilities(BrowseTheWeb ability, IWebDriverFactory factory)
    {
      var browserName = factory.GetBrowserName();

      ability.AddCapabilityExceptWhereUnsupported(Capabilities.ClearDomainCookies,
                                                  browserName,
                                                  BrowserName.Edge);
      ability.AddCapabilityWhereSupported(Capabilities.EnterDatesInLocaleFormat,
                                          browserName,
                                          BrowserName.Chrome);
      ability.AddCapabilityExceptWhereUnsupported(Capabilities.EnterDatesAsIsoStrings,
                                                  browserName,
                                                  BrowserName.Chrome,
                                                  BrowserName.Edge);
    }

    string GetTestName(IServiceResolver resolver)
    {
      var scenarioName = resolver.GetService<IScenarioName>();
      return $"{scenarioName.FeatureId.Name} -> {scenarioName.ScenarioId.Name}";
    }
  }
}
