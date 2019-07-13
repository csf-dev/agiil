using System;
using Agiil.Data.MappingProviders;
using Agiil.Domain.Tickets;
using CSF.Reflection;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ClassMappings
{
  public class HierarchicalTicketRelationshipMapping : IConventionMapping
  {
    readonly IDbNameFormatter nameFormatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.Class<HierarchicalTicketRelationship>(map => {
        map.Mutable(false);

        map.ManyToOne(x => x.Ticket, m => {
          m.Column(nameFormatter.GetForeignKeyColumnName(Reflect.Property<HierarchicalTicketRelationship>(x => x.Ticket)));
        });
        map.ManyToOne(x => x.RelatedTicket, m => {
          m.Column(nameFormatter.GetForeignKeyColumnName(Reflect.Property<HierarchicalTicketRelationship>(x => x.RelatedTicket)));
        });
        map.ManyToOne(x => x.TicketRelationship, m => {
          m.Column(nameFormatter.GetForeignKeyColumnName(Reflect.Property<HierarchicalTicketRelationship>(x => x.TicketRelationship)));
        });
      });
    }

    public HierarchicalTicketRelationshipMapping(IDbNameFormatter nameFormatter)
    {
      if(nameFormatter == null)
        throw new ArgumentNullException(nameof(nameFormatter));
      this.nameFormatter = nameFormatter;
    }
  }
}
