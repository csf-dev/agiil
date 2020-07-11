using System;
namespace Agiil.Domain.Projects
{
    public class CreateProjectRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
