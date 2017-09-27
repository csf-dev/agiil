using System;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class CommentToCommentDtoProfile : Profile
  {
    public CommentToCommentDtoProfile(MarkdownToHtmlResolver markdownResolver)
    {
      CreateMap<Comment,CommentDto>()
        .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.Timestamp, o => o.ResolveUsing(c => c.CreationTimestamp))
        .ForMember(x => x.Author, o => o.ResolveUsing(c => c.User.Username))
        .ForMember(x => x.HtmlBody, o => o.ResolveUsing(markdownResolver, m => m.Body))
        ;
    }
  }
}
