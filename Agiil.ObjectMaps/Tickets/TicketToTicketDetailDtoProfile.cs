using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
    public class TicketToTicketDetailDtoProfile : Profile
    {
        public TicketToTicketDetailDtoProfile()
        {
            CreateMap<Ticket, TicketDetailDto>()
              .ForCtorParam("uriProvider", x => x.ResolveUsing((t, r) => r.Mapper.ServiceCtor(typeof(IGetsTicketUris))))
              .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
              .ForMember(x => x.Creator, o => o.ResolveUsing(t => t.User.Username))
              .ForMember(x => x.Created, o => o.ResolveUsing(t => t.CreationTimestamp))
              .ForMember(x => x.TicketReference, o => o.ResolveUsing(t => t.GetTicketReference()))
              .ForMember(x => x.HtmlDescription, o => o.ResolveUsing<MarkdownToHtmlResolver, string>(m => m.Description))
              .ForMember(x => x.TypeName, o => o.ResolveUsing(t => t.Type?.Name))
              .ForMember(x => x.CommaSeparatedLabelNames, o => o.ResolveUsing<CommaSeparatedLabelNameResolver, ISet<Label>>(t => t.Labels))
              .ForMember(x => x.TotalWorkLogged, o => o.ResolveUsing<TotalWorkLoggedForTicketResolver>())
              .ForMember(x => x.CanEdit, o => o.Ignore())
              .ForMember(x => x.Relationships, o => o.Ignore())
              .AfterMap((ticket, dto, ctx) => {
                  var summaryProvider = (IGetsRelationshipSummary) ctx.Mapper.ServiceCtor(typeof(IGetsRelationshipSummary));
                  dto.Comments = GetOrderedComments(dto);
                  dto.Relationships = GetRelationships(ticket, summaryProvider, ctx);
              })
              ;
        }

        IEnumerable<TicketRelationshipDto> GetRelationships(Ticket ticket,
                                                            IGetsRelationshipSummary summaryProvider,
                                                            ResolutionContext ctx)
        {
            return GetRelationships(ticket.PrimaryRelationships, RelationshipParticipant.Primary, summaryProvider, ctx)
              .Union(GetRelationships(ticket.SecondaryRelationships, RelationshipParticipant.Secondary, summaryProvider, ctx));
        }

        IEnumerable<TicketRelationshipDto> GetRelationships(IEnumerable<TicketRelationship> relationships,
                                                            RelationshipParticipant participant,
                                                            IGetsRelationshipSummary summaryProvider,
                                                            ResolutionContext ctx)
        {
            return relationships
              .Where(x => x != null)
              .Select(x => GetRelationship(x, participant, summaryProvider, ctx))
              .ToArray();
        }

        TicketRelationshipDto GetRelationship(TicketRelationship relationship,
                                              RelationshipParticipant participant,
                                              IGetsRelationshipSummary summaryProvider,
                                              ResolutionContext ctx)
        {

            Ticket relatedTicket;
            if(participant == RelationshipParticipant.Primary)
                relatedTicket = relationship.SecondaryTicket;
            else
                relatedTicket = relationship.PrimaryTicket;

            return new TicketRelationshipDto {
                Id = relationship.GetIdentity(),
                RelationshipId = relationship.Relationship?.GetIdentity(),
                Summary = summaryProvider.GetSummary(relationship.Relationship, participant),
                Participant = participant,
                RelatedTicket = ctx.Mapper.Map<TicketSummaryDto>(relatedTicket),
            };
        }

        IReadOnlyList<CommentDto> GetOrderedComments(TicketDetailDto dto)
        {
            return dto.Comments.OrderBy(x => x.Timestamp).ToArray();
        }
    }
}
