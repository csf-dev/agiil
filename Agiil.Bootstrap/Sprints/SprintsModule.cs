using System;
using Agiil.Domain.Sprints;
using Autofac;

namespace Agiil.Bootstrap.Sprints
{
  public class SprintsModule : NamespaceModule
  {
    protected override string Namespace => typeof(SprintCreator).Namespace;
  }
}
