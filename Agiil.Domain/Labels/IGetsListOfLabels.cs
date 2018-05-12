using System;
using System.Collections.Generic;

namespace Agiil.Domain.Labels
{
  public interface IGetsListOfLabels
  {
    IReadOnlyList<ListedLabel> GetAllLabels();
  }
}
