using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.Services.Tickets
{
  public interface IGetsEditTicketModel
  {
    EditTicketModel GetEditTicketModel(Ticket ticket);
  }
}
