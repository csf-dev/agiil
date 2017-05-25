using System;
namespace Agiil.Web.Models.Tickets
{
  public class EditTicketTitleAndDescriptionResponse
  {
    public bool TitleIsInvalid { get; set; }

    public bool DescriptionIsInvalid { get; set; }

    public bool Success { get; set; }
  }
}
