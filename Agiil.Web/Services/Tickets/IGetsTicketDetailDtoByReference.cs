using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.Services.Tickets
{
  public interface IGetsTicketDetailDtoByReference
  {
    TicketDetailDto GetTicketDetailDto(TicketReference reference);
  }
}
