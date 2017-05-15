using System;
namespace Agiil.Web.Models
{
  public class EditTicketTitleAndDescriptionResponse
  {
    public bool TitleIsInvalid { get; set; }

    public bool DescriptionIsInvalid { get; set; }

    public bool Success { get; set; }
  }
}
