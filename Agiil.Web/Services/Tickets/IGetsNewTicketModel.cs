using System;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.Services.Tickets
{
  public interface IGetsNewTicketModel
  {
    NewTicketModel GetNewTicketModel(NewTicketSpecification spec);
  }
}
