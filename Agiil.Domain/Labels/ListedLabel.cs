using System;
using CSF.Entities;

namespace Agiil.Domain.Labels
{
  public class ListedLabel
  {
    public string Name { get; set; }

    public int CountOfOpenTickets { get; set; }

    public int CountOfClosedTickets { get; set; }
  }
}
