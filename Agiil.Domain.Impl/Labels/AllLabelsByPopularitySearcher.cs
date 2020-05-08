﻿using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Tickets.Specs;
using CSF.ORM;
using CSF.Specifications;

namespace Agiil.Domain.Labels
{
  public class AllLabelsByPopularitySearcher : ISearchesForLabels
  {
    readonly IEntityData data;
    readonly IsOpen isOpen;
    readonly IsClosed isClosed;

    public IReadOnlyList<ListedLabel> GetLabels(string searchQuery, int? maxResults = null)
    {
      var query =  (from label in data.Query<Label>()
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

    public AllLabelsByPopularitySearcher(IEntityData entityData, IsOpen isOpen, IsClosed isClosed)
    {
      if(isClosed == null)
        throw new ArgumentNullException(nameof(isClosed));
      if(isOpen == null)
        throw new ArgumentNullException(nameof(isOpen));
      if(entityData == null)
        throw new ArgumentNullException(nameof(entityData));
      this.data = entityData;
      this.isOpen = isOpen;
      this.isClosed = isClosed;
    }
  }
}
