using System;
using Agiil.Data.MappingProviders;
using Agiil.Domain.Tickets;
using CSF.Reflection;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ClassMappings
{
  public class TicketRelationshipMapping : IConventionMapping
  {
    readonly IDbNameFormatter nameFormatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.Class<TicketRelationship>(map => {
        map.ManyToOne(x => x.PrimaryTicket, propMap => {
          propMap.Column(nameFormatter.GetForeignKeyColumnName(Reflect.Property<TicketRelationship>(x => x.PrimaryTicket)));
          propMap.ForeignKey(nameFormatter.GetForeignKeyConstraintName(Reflect.Property<TicketRelationship>(x => x.PrimaryTicket), typeof(TicketRelationship)));
          propMap.Index(nameFormatter.GetIndexName(typeof(TicketRelationship), Reflect.Property<TicketRelationship>(x => x.PrimaryTicket)));
          propMap.Cascade(Cascade.Persist);
        });

        map.ManyToOne(x => x.SecondaryTicket, propMap => {
          propMap.Column(nameFormatter.GetForeignKeyColumnName(Reflect.Property<TicketRelationship>(x => x.SecondaryTicket)));
          propMap.ForeignKey(nameFormatter.GetForeignKeyConstraintName(Reflect.Property<TicketRelationship>(x => x.SecondaryTicket), typeof(TicketRelationship)));
          propMap.Index(nameFormatter.GetIndexName(typeof(TicketRelationship), Reflect.Property<TicketRelationship>(x => x.SecondaryTicket)));
          propMap.Cascade(Cascade.Persist);
        });
      });
    }

    public TicketRelationshipMapping(IDbNameFormatter nameFormatter)
    {
      if(nameFormatter == null)
        throw new ArgumentNullException(nameof(nameFormatter));
      this.nameFormatter = nameFormatter;
    }
  }
}
