using System;
namespace Agiil.Web.Models.Projects
{
    public class CreateProjectModel : PageModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
