using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  /// <summary>
  /// 'Fake' immutable entity (really, a DTO) representing a hierarchy of directional relationships, following
  /// the same relationship type in a chain from parent-to-child (or vice/versa) such that deep ancestor/descendent
  /// relationships may be analysed.
  /// </summary>
  public class HierarchicalTicketRelationship : Entity<long>
  {
    public virtual Ticket Ticket { get; protected set; }
    public virtual Ticket RelatedTicket { get; protected set; }
    public virtual HierarchicalRelationshipDirection Direction { get; protected set; }
    public virtual TicketRelationship TicketRelationship { get; protected set; }
  }
}
