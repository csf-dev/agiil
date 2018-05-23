using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Agiil.Domain.Data;
using Agiil.Web.App_Start;
using Agiil.Web.Controllers;

namespace Agiil.Web.ActionFilters
{
  public class TestApplicationDependencies: IActionFilter
  {
    static readonly Type[] MaintenanceControllerTypes = {
        typeof(DatabaseController),
        typeof(DatabaseBackupController),
      };
    static readonly Type MissingDependenciesControllerType = typeof(MissingDependenciesController);

    readonly ITestsApplicationDependencies dependencyTester;

    public void OnActionExecuted(ActionExecutedContext filterContext) { /* No-op */ }

    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
      if(ShouldSkipTests(filterContext)) return;

      var testResult = dependencyTester.TestApplicationDependencies();
      if(testResult.IsApplicationOKToUse) return;

      if(testResult.IsApplicationViableForMaintenance)
      {
        if(ShouldRedirectToMaintenanceMode(filterContext))
          RedirectToMaintenanceMode(filterContext);
        
        return;
      }

      RedirectToUnusableMessage(filterContext);
    }

    bool ShouldRedirectToMaintenanceMode(ActionExecutingContext filterContext)
    {
      if(MaintenanceControllerTypes.Contains(filterContext?.Controller?.GetType())) return false;

      return true;
    }

    bool ShouldSkipTests(ActionExecutingContext filterContext)
    {
      return filterContext?.Controller?.GetType() == MissingDependenciesControllerType;
    }

    void RedirectToMaintenanceMode(ActionExecutingContext filterContext)
    {
      filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
        { "controller", RouteConfiguration.GetControllerName<MissingDependenciesController>() },
        { "action"    , nameof(MissingDependenciesController.RequireMaintenance) },
      });
    }

    void RedirectToUnusableMessage(ActionExecutingContext filterContext)
    {
      filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
        { "controller", RouteConfiguration.GetControllerName<MissingDependenciesController>() },
        { "action"    , nameof(MissingDependenciesController.Unusable) },
      });
    }

    public TestApplicationDependencies(ITestsApplicationDependencies dependencyTester)
    {
      if(dependencyTester == null)
        throw new ArgumentNullException(nameof(dependencyTester));
      this.dependencyTester = dependencyTester;
    }
  }
}
