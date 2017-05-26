using System;
using System.Collections.Generic;
using Agiil.Bootstrap;
using Agiil.Tests.Sprints;

namespace Agiil.Tests.Bootstrap
{
  public class SprintsModule : NamespaceModule
  {
    protected override IEnumerable<System.Reflection.Assembly> GetSearchAssemblies()
    {
      return new [] { System.Reflection.Assembly.GetExecutingAssembly() };
    }

    protected override string Namespace => typeof(ISprintCreationController).Namespace;
  }
}
