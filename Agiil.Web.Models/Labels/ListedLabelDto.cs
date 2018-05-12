using System;
namespace Agiil.Web.Models.Labels
{
  public class ListedLabelDto : LabelDto
  {
    public int CountOfOpenTickets { get; set; }

    public int CountOfClosedTickets { get; set; }
  }
}
