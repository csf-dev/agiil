using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Data.ClassMappings;

namespace Agiil.Bootstrap.Data
{
  public class ClassMappingsModule : NamespaceModule
  {
    protected override string Namespace => typeof(LabelMapping).Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
      => new [] { typeof(LabelMapping).Assembly };
  }
}
