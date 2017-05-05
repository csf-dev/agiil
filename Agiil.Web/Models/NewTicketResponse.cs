using System;
namespace Agiil.Web.Models
{
  public class NewTicketResponse
  {
    public object TicketIdentity { get; set; }

    public bool TitleIsInvalid { get; set; }

    public bool DescriptionIsInvalid { get; set; }
  }
}
