using System;
using System.Collections.Generic;

namespace Agiil.Domain.Labels
{
  public interface ISearchesForLabels
  {
    IReadOnlyList<ListedLabel> GetLabels(string searchQuery, int? maxResults = null);
  }
}
