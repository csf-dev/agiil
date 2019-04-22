using System;
using System.Collections.Generic;
using CSF.FlexDi;
using CSF.Screenplay.Integration;
using CSF.Screenplay.Scenarios;
using CSF.Screenplay.Selenium;
using CSF.WebDriverExtras;
using CSF.WebDriverExtras.Flags;
using OpenQA.Selenium;

namespace Agiil.BDD.WebDriver
{
  public static class AgiilWebDriverIntegrationBuilderExtensions
  {
    public static void UseAgiilWebDriverFromConfiguration(this IIntegrationConfigBuilder builder,
                                                          string name = null)
    {
      if(builder == null)
        throw new ArgumentNullException(nameof(builder));

      builder.ServiceRegistrations.PerTestRun.Add(b => {
        b.RegisterFactory(() => GetWebDriverFactory.FromConfiguration())
         .AsOwnType()
         .WithName(name);
      });

      builder.ServiceRegistrations.PerScenario.Add(b => {
        b.RegisterDynamicFactory(GetLazyWebDriverTracker(name))
         .As<ITracksWebDriverCreation>()
         .WithName(name);

        b.RegisterDynamicFactory(resolver => resolver.Resolve<ITracksWebDriverCreation>().GetWebDriver())
         .AsOwnType()
         .WithName(name);
      });

      builder.AfterScenario.Add(MarkWebDriverWithOutcome(name));
    }

    static Func<IResolvesServices,LazyWebDriverCreationTracker> GetLazyWebDriverTracker(string name)
    {
      return resolver => {
        var webDriverResolver = GetWebDriverResolver(name);
        return new LazyWebDriverCreationTracker(new Lazy<IWebDriver>(() => webDriverResolver(resolver)));
      };
    }

    static Func<IResolvesServices,IWebDriver> GetWebDriverResolver(string name)
    {
      return resolver => {
        var factory = resolver.Resolve<ICreatesWebDriver>(name);
        var scenario = resolver.Resolve<IScenarioName>();
        var flagsProvider = resolver.TryResolve<IGetsBrowserFlags>();
        var capabilities = GetRequestedCapabilities();

        return factory.CreateWebDriver(flagsProvider: flagsProvider,
                                       scenarioName: GetHumanReadableName(scenario),
                                       requestedCapabilities: capabilities);
      };
    }

    static IDictionary<string,object> GetRequestedCapabilities()
    {
      var envVariable = Environment.GetEnvironmentVariable("AgiilExtendedBrowserDebugging");
      if(envVariable != Boolean.TrueString) return null;

      return new Dictionary<string,object> {
        { "extendedDebugging", true }
      };
    }

    static Action<IScenario> MarkWebDriverWithOutcome(string name)
    {
      return scenario => {
        if(!scenario.Success.HasValue) return;
        var success = scenario.Success.Value;

        var webDriverTracker = scenario.DiContainer.TryResolve<ITracksWebDriverCreation>(name);
        if(webDriverTracker == null) return;
        if(!webDriverTracker.HasWebDriverBeenCreated) return;

        var webDriver = webDriverTracker.GetWebDriver();

        var receivesStatus = webDriver as ICanReceiveScenarioOutcome;
        if(receivesStatus == null) return;

        receivesStatus.MarkScenarioWithOutcome(success);
      };
    }

    static string GetHumanReadableName(IScenarioName scenario) => $"{scenario.FeatureId.Name}: {scenario.ScenarioId.Name}";
  }
}
