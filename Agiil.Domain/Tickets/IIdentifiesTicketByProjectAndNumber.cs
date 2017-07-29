using System;
namespace Agiil.Domain.Tickets
{
  public interface IIdentifiesTicketByProjectAndNumber
  {
    long TicketNumber { get; }

    string ProjectCode { get; }
  }
}
