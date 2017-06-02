using System;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public interface INewTicketController
  {
    void Create(NewTicketSpecification request);
  }
}
