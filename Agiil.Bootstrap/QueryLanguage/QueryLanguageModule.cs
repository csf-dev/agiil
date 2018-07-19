﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.QueryLanguage;

namespace Agiil.Bootstrap.QueryLanguage
{
  public class QueryLanguageModule : NamespaceModule
  {
		protected override IEnumerable<Assembly> GetSearchAssemblies()
		{
      return new [] {
        QueryLanguageImplAssemblyMarker.Instance.Assembly,
      };
		}

    protected override string Namespace => typeof(QueryLanguageImplAssemblyMarker).Namespace;
	}
}
