using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Data.ConventionMappings;

namespace Agiil.Bootstrap.Data
{
  public class ConventionMappingsModule : NamespaceModule
  {
    protected override string Namespace => typeof(PropertyMapping).Namespace;

		protected override IEnumerable<Assembly> GetSearchAssemblies()
      => new [] { typeof(PropertyMapping).Assembly };
  }
}
