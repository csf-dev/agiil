using System;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Agiil.Web.Controllers;

namespace Agiil.Web.App_Start
{
  public class RouteConfiguration
  {
    #region constants

    internal const string
      ApiPrefix = "api",
      OAuthPrefix = "/oauth2",
      OAuthTokenPath = OAuthPrefix + "/token";

    const string ControllerNamePattern = "^(.+)Controller$";
    static readonly Regex ControllerNameMatcher = new Regex(ControllerNamePattern, RegexOptions.Compiled);

    #endregion

    #region methods

    public void RegisterMvcRoutes (RouteCollection routes)
    {
      routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
      //routes.IgnoreRoute("api/{*pathInfo}");
      //routes.IgnoreRoute("oauth2/{*pathInfo}");

      routes.MapMvcAttributeRoutes();

      routes.MapRoute (
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }

    public void RegisterWebApiRoutes(HttpConfiguration config)
    {
      config.MapHttpAttributeRoutes ();

      config.Routes.MapHttpRoute (
        name: "DefaultApi",
        routeTemplate: "api/v1/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional }
      );
    }

    #endregion

    #region static methods

    internal static string GetMvcLoginPath()
    {
      return String.Concat("/", GetControllerName<LoginController>());
    }

    internal static string GetControllerName<TController>() where TController : Controller
    {
      var typeName = typeof(TController).Name;
      var match = ControllerNameMatcher.Match(typeName);
      if(match.Success)
      {
        return match.Groups[1].Value;
      }

      return typeName;
    }

    #endregion
  }
}
