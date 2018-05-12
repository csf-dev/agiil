using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Tickets;
using CSF.Data.Entities;
using CSF.Data.Specifications;

namespace Agiil.Domain.Labels
{
  public class LabelLister : IGetsListOfLabels
  {
    readonly IEntityData data;
    readonly IsOpen isOpen;
    readonly IsClosed isClosed;

    public IReadOnlyList<ListedLabel> GetAllLabels()
    {
      return (from label in data.Query<Label>()
              let openCount = label.Tickets.Count(isOpen)
              let closedCount = label.Tickets.Count(isClosed)
              orderby label.Name
              select new ListedLabel {
                Name = label.Name,
                CountOfOpenTickets = openCount,
                CountOfClosedTickets = closedCount
              })
        .ToArray();
    }

    public LabelLister(IEntityData data, IsOpen isOpen, IsClosed isClosed)
    {
      if(isClosed == null)
        throw new ArgumentNullException(nameof(isClosed));
      if(isOpen == null)
        throw new ArgumentNullException(nameof(isOpen));
      if(data == null)
        throw new ArgumentNullException(nameof(data));

      this.data = data;
      this.isOpen = isOpen;
      this.isClosed = isClosed;
    }
  }
}
