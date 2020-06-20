using System;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    public class EditProjectRequest
    {
        public IIdentity<Project> Identity { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
