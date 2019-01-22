using System;
using System.Collections.Generic;
using CSF.Data.Entities;

namespace Agiil.Domain.Labels
{
  public class LabelSearcher : ISearchesForLabels
  {
    readonly Func<ISearchesForLabels> allLabelsSearcher, matchingLabelsSearcher;

    public IReadOnlyList<ListedLabel> GetLabels(string searchQuery, int? maxResults = null)
    {
      var impl = String.IsNullOrEmpty(searchQuery)? allLabelsSearcher() : matchingLabelsSearcher();
      return impl.GetLabels(searchQuery, maxResults);
    }

    public LabelSearcher(Func<AllLabelsByPopularitySearcher> allLabelsSearcher,
                         Func<LabelsMatchingSearchByRelevanceSearcher> matchingLabelsSearcher)
    {
      if(matchingLabelsSearcher == null)
        throw new ArgumentNullException(nameof(matchingLabelsSearcher));
      if(allLabelsSearcher == null)
        throw new ArgumentNullException(nameof(allLabelsSearcher));
      this.allLabelsSearcher = allLabelsSearcher;
      this.matchingLabelsSearcher = matchingLabelsSearcher;
    }
  }
}
