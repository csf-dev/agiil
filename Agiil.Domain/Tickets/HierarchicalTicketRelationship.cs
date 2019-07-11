namespace Agiil.Domain.Tickets
{
  public class HierarchicalTicketRelationship
  {
    public virtual Ticket Ticket { get; protected set; }
    public virtual Ticket RelatedTicket { get; protected set; }
    public virtual HierarchicalRelationshipDirection Direction { get; protected set; }
    public virtual TicketRelationship TicketRelationship { get; protected set; }
  }
}
