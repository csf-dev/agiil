﻿using System;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Agiil.Web.Controllers;
using Agiil.Web.OAuth;

namespace Agiil.Web.App_Start
{
  public class RouteConfiguration : IOAuthPathProvider
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

    public string GetTokenPath()
    {
      return OAuthTokenPath;
    }

    #endregion

    #region static methods

    internal static string GetMvcLoginPath()
    {
      return String.Concat("/", GetControllerName<LoginController>());
    }

    internal static string GetControllerName<TController>() where TController : Controller
    {
      return GetControllerName(typeof(TController));
    }

    internal static string GetControllerName(Type controllerType)
    {
      if(controllerType == null)
        throw new ArgumentNullException(nameof(controllerType));
      if(!typeof(Controller).IsAssignableFrom(controllerType))
        throw new ArgumentException($"The given type must implement {nameof(Controller)}.", nameof(controllerType));

      var typeName = controllerType.Name;
      var match = ControllerNameMatcher.Match(typeName);
      if(match.Success)
        return match.Groups[1].Value;

      return typeName;
    }

    #endregion
  }
}
