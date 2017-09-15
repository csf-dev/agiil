using System;
namespace Agiil.Web.Models.Tickets
{
  public class EditTicketResponse
  {
    public bool TitleIsInvalid { get; set; }

    public bool DescriptionIsInvalid { get; set; }

    public bool Success { get; set; }

    public bool Failure => !Success;

    public bool SprintIsInvalid { get; set; }
  }
}
