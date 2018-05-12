using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.BDD.Models.Labels
{
  public class LabelNames
  {
    public ICollection<string> Names { get; }

    public LabelNames()
    {
      Names = new List<string>();
    }
  }
}
