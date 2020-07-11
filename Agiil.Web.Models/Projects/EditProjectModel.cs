using System;
using Agiil.Domain.Projects;
using CSF.Entities;

namespace Agiil.Web.Models.Projects
{
    public class EditProjectModel
    {
        public IIdentity<Project> Identity { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public EditProjectRequest Request { get; set; }
        public EditProjectResponse Response { get; set; }
    }
}
