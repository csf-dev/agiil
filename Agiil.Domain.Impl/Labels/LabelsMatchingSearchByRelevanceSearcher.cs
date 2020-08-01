using System;
using System.Collections.Generic;
using System.Linq;
using CSF.ORM;
using CSF.Specifications;

namespace Agiil.Domain.Labels
{
    public class LabelsMatchingSearchByRelevanceSearcher : ISearchesForLabels
    {
        readonly IEntityData data;

        public IReadOnlyList<ListedLabel> GetLabels(string searchQuery, int? maxResults = null)
        {
            var queryStr = searchQuery ?? String.Empty;

            var query = (from label in data.Query<Label>()
                         let openCount = label.Tickets.Count(x => !x.Closed)
                         let closedCount = label.Tickets.Count(x => x.Closed)
                         let exactMatch = label.Name.Equals(queryStr)
                         let startsWith = label.Name.StartsWith(queryStr)
                         let contains = label.Name.Contains(queryStr)
                         let relevance = (
                           exactMatch ? 0 :
                           startsWith ? 1 :
                           contains ? 2 :
                                       3
                         )
                         where exactMatch || startsWith || contains
                         orderby relevance
                         select new ListedLabel {
                             Name = label.Name,
                             CountOfOpenTickets = openCount,
                             CountOfClosedTickets = closedCount
                         });

            if(maxResults.HasValue && maxResults.Value > 0)
                query = query.Take(maxResults.Value);

            return query.ToArray();
        }

        public LabelsMatchingSearchByRelevanceSearcher(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
