using System;
using Agiil.Data.MappingProviders;
using Agiil.Domain.Tickets;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ClassMappings
{
  public class HierarchicalTicketRelationshipMapping : IConventionMapping
  {
    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.Class<HierarchicalTicketRelationship>(map => {
        map.Mutable(false);

        map.ManyToOne(x => x.Ticket);
        map.ManyToOne(x => x.RelatedTicket);
        map.ManyToOne(x => x.TicketRelationship);
        map.Property(x => x.Direction);
      });
    }
  }
}
