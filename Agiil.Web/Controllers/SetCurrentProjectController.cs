using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Projects;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
    public class SetCurrentProjectController : Controller
    {
        readonly ISetsCurrentProject projectSetter;

        [HttpPost]
        public ActionResult Index(IIdentity<Project> projectId)
        {
            projectSetter.SetCurrentProject(projectId);
            return Redirect(Request?.UrlReferrer?.ToString() ?? String.Empty);
        }

        public SetCurrentProjectController(ISetsCurrentProject projectSetter)
        {
            this.projectSetter = projectSetter ?? throw new ArgumentNullException(nameof(projectSetter));
        }
    }
}
