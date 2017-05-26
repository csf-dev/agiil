using System;
namespace Agiil.Web.Models.Tickets
{
  public class NewTicketResponse
  {
    public object TicketIdentity { get; set; }

    public bool TitleIsInvalid { get; set; }

    public bool DescriptionIsInvalid { get; set; }

    public bool Success => !ReferenceEquals(TicketIdentity, null);
  }
}
