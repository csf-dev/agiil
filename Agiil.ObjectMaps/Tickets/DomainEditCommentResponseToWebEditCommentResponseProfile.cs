using System;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
    public class DomainEditCommentResponseToWebEditCommentResponseProfile : Profile
    {
        public DomainEditCommentResponseToWebEditCommentResponseProfile()
        {
            CreateMap<Domain.Tickets.EditCommentResponse, Web.Models.Tickets.EditCommentResponse>()
                .ForMember(x => x.Success, o => o.ResolveUsing(x => x.IsSuccess));
        }
    }
}
