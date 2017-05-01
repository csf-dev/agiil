using System;
namespace Agiil.Web.Models
{
  public class NewTicketModel
  {
    public string Title { get; set; }

    public string Description { get; set; }

    bool TitleIsInvalid { get; set; }

    bool DescriptionIsInvalid { get; set; }
  }
}
