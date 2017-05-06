using System;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public interface INewTicketController
  {
    void Create(NewTicketSpecification request);
  }
}
