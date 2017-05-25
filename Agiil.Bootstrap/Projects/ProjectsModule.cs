using System;
using Agiil.Domain.Projects;

namespace Agiil.Bootstrap.Projects
{
  public class ProjectsModule : NamespaceModule
  {
    protected override string Namespace => typeof(ICurrentProjectGetter).Namespace;
  }
}
