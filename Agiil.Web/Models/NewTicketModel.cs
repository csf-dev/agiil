using System;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class NewTicketModel : StandardPageModel
  {
    public NewTicketSpecification Specification { get; set; }

    public NewTicketResponse Response { get; set; }

    public NewTicketModel()
    {
      Specification = new NewTicketSpecification();
    }
  }
}
