using System;
using Agiil.Domain.Capabilities;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class CommentToCommentDtoProfile : Profile
  {
    public CommentToCommentDtoProfile()
    {
      CreateMap<Comment,CommentDto>()
        .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.Timestamp, o => o.ResolveUsing(c => c.CreationTimestamp))
        .ForMember(x => x.Author, o => o.ResolveUsing(c => c.User.Username))
        .ForMember(x => x.HtmlBody, o => o.ResolveUsing<MarkdownToHtmlResolver, string>(m => m.Body))
        .ForMember(x => x.TicketId, o => o.ResolveUsing<IdentityValueResolver, Ticket>(x => x.Ticket))
        .AfterMap((comment, commentDto, ctx) => {
            var capabilitiesService = (IDeterminesIfCurrentUserHasCapability) ctx.Mapper.ServiceCtor(typeof(IDeterminesIfCurrentUserHasCapability));
            commentDto.CanEdit = capabilitiesService.DoesUserHaveCapability(CommentCapability.Edit, comment.GetIdentity());
            commentDto.CanDelete = capabilitiesService.DoesUserHaveCapability(CommentCapability.Delete, comment.GetIdentity());
        })
        ;
    }
  }
}
