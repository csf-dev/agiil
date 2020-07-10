using System;
using Agiil.Web.Models.Projects;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
    public class PageModel : IHasLoginState, IHasApplicationVersion, IHasBaseUri, IHasAvailableProjects
    {
        public LoginStateModel LoginState { get; set; }

        public ApplicationVersionInfo ApplicationVersion { get; set; }

        public BaseUriModel BaseUri { get; set; }

        public AvailableProjectsModel AvailableProjects { get; set; }
    }
}
