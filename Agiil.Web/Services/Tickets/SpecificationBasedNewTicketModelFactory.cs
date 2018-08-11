using System;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.Services.Tickets
{
  public class SpecificationBasedNewTicketModelFactory : IGetsNewTicketModel
  {
    public NewTicketModel GetNewTicketModel(NewTicketSpecification spec)
    {
      return new NewTicketModel {
        Specification = spec,
      };
    }
  }
}
