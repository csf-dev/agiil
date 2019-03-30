using System;
namespace Agiil.Domain.Activity
{
  public interface IGetsSumOfLoggedWorkForTicket
  {
    TimeSpan GetTotalTimeLogged(Tickets.Ticket ticket);
  }
}
