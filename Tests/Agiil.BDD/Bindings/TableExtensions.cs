using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings
{
  public static class TableExtensions
  {
    public static IReadOnlyList<string> ToListOfStrings(this Table table)
    {
      return table.Rows.Select(x => x.Values.Single()).ToArray();
    }
  }
}
