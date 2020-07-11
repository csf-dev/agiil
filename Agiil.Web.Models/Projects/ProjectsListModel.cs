using System;
using System.Collections.Generic;

namespace Agiil.Web.Models.Projects
{
    public class ProjectsListModel : PageModel
    {
        public IList<ProjectDescriptionDto> Projects { get; set; }
    }
}
