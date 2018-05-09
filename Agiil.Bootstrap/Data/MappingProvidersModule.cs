using System.Collections.Generic;
using System.Reflection;
using Agiil.Data.MappingProviders;

namespace Agiil.Bootstrap.Data
{
  public class MappingProvidersModule : NamespaceModule
  {
    protected override string Namespace => typeof(IGetsHbmMapping).Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
      => new [] { typeof(IGetsHbmMapping).Assembly };
  }
}
