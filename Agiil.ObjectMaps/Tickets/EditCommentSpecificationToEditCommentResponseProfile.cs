using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
    public class EditCommentSpecificationToEditCommentRequestProfile : Profile
    {
        public EditCommentSpecificationToEditCommentRequestProfile()
        {
            CreateMap<EditCommentSpecification, EditCommentRequest>()
                .ForMember(x => x.CommentIdentity, o => o.ResolveUsing(x => x.CommentId));
        }
    }
}
