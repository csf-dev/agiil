using System;
using System.Linq;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    public class ProjectProvider : IGetsProject
    {
        readonly IEntityData data;

        public Project GetProject(string code)
        {
            return data.Query<Project>().FirstOrDefault(x => x.Code == code);
        }

        public ProjectProvider(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
