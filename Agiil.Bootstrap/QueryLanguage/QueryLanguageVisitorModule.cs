using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.QueryLanguage;
using Agiil.QueryLanguage.Visitors;

namespace Agiil.Bootstrap.QueryLanguage
{
  public class QueryLanguageVisitorModule : NamespaceModule
  {
    protected override IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] {
        QueryLanguageImplAssemblyMarker.Instance.Assembly,
      };
    }

    protected override string Namespace => typeof(SearchVisitor).Namespace;
  }
}
