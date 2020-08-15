using System;
using System.Collections.Generic;
using System.Linq;
using CSF.ORM;
using CSF.Specifications;

namespace Agiil.Domain.Labels
{
    public class AllLabelsByPopularitySearcher : ISearchesForLabels
    {
        readonly IEntityData data;

        public IReadOnlyList<ListedLabel> GetLabels(string searchQuery, int? maxResults = null)
        {
            var query = (from label in data.Query<Label>()
                         let openCount = label.Tickets.Count(x => !x.Closed)
                         let closedCount = label.Tickets.Count(x => x.Closed)
                         orderby openCount descending
                         select new ListedLabel {
                             Name = label.Name,
                             CountOfOpenTickets = openCount,
                             CountOfClosedTickets = closedCount
                         });

            if(maxResults.HasValue && maxResults.Value > 0)
                query = query.Take(maxResults.Value);

            return query.ToArray();
        }

        public AllLabelsByPopularitySearcher(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
