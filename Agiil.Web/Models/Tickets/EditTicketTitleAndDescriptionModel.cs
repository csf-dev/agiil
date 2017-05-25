using System;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models.Tickets
{
  public class EditTicketTitleAndDescriptionModel : StandardPageModel
  {
    public TicketDetailDto  Ticket { get; set; }

    public EditTicketTitleAndDescriptionSpecification Specification { get; set; }

    public EditTicketTitleAndDescriptionResponse Response { get; set; }

    public EditTicketTitleAndDescriptionModel()
    {
      Specification = new EditTicketTitleAndDescriptionSpecification();
    }
  }
}
