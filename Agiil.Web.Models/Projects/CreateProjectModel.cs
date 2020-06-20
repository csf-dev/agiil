using System;
using Agiil.Domain.Projects;

namespace Agiil.Web.Models.Projects
{
    public class CreateProjectModel : PageModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public CreateProjectResponse Response { get; set; }
    }
}
