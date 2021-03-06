﻿using System;
using System.Web.Mvc;
using Agiil.Domain;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.ActionFilters
{
    public class VersionInfoModelPopulator : IActionFilter
    {
        readonly IProvidesVersionInformation versionInfoProvider;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if(viewResult == null) return;

            viewResult.ViewBag.ApplicationVersion = new ApplicationVersionInfo {
                HumanReadableProductVersion = versionInfoProvider.GetHumanReadableProductVersion(),
                ComponentVersions = versionInfoProvider.GetComponentVersions(),
            };
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) { /* No-op */ }

        public VersionInfoModelPopulator(IProvidesVersionInformation versionInfoProvider)
        {
            if(versionInfoProvider == null)
                throw new ArgumentNullException(nameof(versionInfoProvider));
            this.versionInfoProvider = versionInfoProvider;
        }
    }
}
