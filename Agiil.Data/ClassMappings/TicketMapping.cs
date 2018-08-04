using System;
using Agiil.Data.MappingProviders;
using Agiil.Domain.Tickets;
using CSF.Reflection;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ClassMappings
{
  public class TicketMapping : IConventionMapping
  {
    readonly IDbNameFormatter nameFormatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.Class<Ticket>(map => {
        map.Set(x => x.PrimaryRelationships, set => {

          set.Key(k => {
            var participant = RelationshipParticipant.Primary.ToString();
            var member = nameof(Ticket);

            k.Column(nameFormatter.GetForeignKeyColumnName(participant, member));
            k.ForeignKey(nameFormatter.GetForeignKeyConstraintName(Reflect.Property<TicketRelationship>(x => x.PrimaryTicket), typeof(TicketRelationship)));
          });
          
        });

        map.Set(x => x.SecondaryRelationships, set => {

          set.Key(k => {
            var participant = RelationshipParticipant.Secondary.ToString();
            var member = nameof(Ticket);

            k.Column(nameFormatter.GetForeignKeyColumnName(participant, member));
            k.ForeignKey(nameFormatter.GetForeignKeyConstraintName(Reflect.Property<TicketRelationship>(x => x.SecondaryTicket), typeof(TicketRelationship)));
          });

        });
      });
    }

    public TicketMapping(IDbNameFormatter nameFormatter)
    {
      if(nameFormatter == null)
        throw new ArgumentNullException(nameof(nameFormatter));
      this.nameFormatter = nameFormatter;
    }
  }
}
