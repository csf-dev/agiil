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
          m.Cascade(Cascade.None);
        });
        map.ManyToOne(x => x.RelatedTicket, m => {
          m.Column(nameFormatter.GetForeignKeyColumnName(Reflect.Property<HierarchicalTicketRelationship>(x => x.RelatedTicket)));
          m.Cascade(Cascade.None);
        });
        map.ManyToOne(x => x.TicketRelationship, m => {
          m.Column(nameFormatter.GetForeignKeyColumnName(Reflect.Property<HierarchicalTicketRelationship>(x => x.TicketRelationship)));
          m.Cascade(Cascade.None);
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
