using System;
using Agiil.Domain.Projects;
using CSF.Entities;

namespace Agiil.Web.Models.Projects
{
    public class AvailableProjectModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public IIdentity<Project> Identity { get; set; }
        public bool IsCurrent { get; set; }

        public string Selected => IsCurrent ? "selected" : null;
        public string Class => IsCurrent ? "current_project" : String.Empty;
    }
}
