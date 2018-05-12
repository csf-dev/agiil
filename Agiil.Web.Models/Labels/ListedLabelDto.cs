using System;
namespace Agiil.Web.Models.Labels
{
  public class ListedLabelDto
  {
    public string Name { get; set; }

    public int CountOfOpenTickets { get; set; }

    public int CountOfClosedTickets { get; set; }
  }
}
