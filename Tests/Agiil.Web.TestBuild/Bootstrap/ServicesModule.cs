using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Bootstrap;
using Agiil.Web.TestBuild.Services;

namespace Agiil.Web.TestBuild.Bootstrap
{
  public class ServicesModule : NamespaceModule
  {
    protected override string Namespace
      => typeof(DatabaseMaintainer).Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
      => new [] { Assembly.GetExecutingAssembly() };
  }
}
