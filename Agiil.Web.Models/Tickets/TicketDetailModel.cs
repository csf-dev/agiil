using System;

namespace Agiil.Web.Models.Tickets
{
  public class TicketDetailModel
  {
    public bool IsSuccessfulEdit { get; set; }

    public TicketDetailDto  Ticket { get; set; }

    public AddCommentSpecification AddCommentSpecification { get; set; }

    public AddCommentResponse AddCommentResponse { get; set; }
  }
}
