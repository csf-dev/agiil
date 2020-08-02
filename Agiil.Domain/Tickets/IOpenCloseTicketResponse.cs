using System;
namespace Agiil.Domain.Tickets
{
    public interface IOpenCloseTicketResponse : IIndictesSuccess
    {
        bool TicketNotFound { get; }
    }
}
