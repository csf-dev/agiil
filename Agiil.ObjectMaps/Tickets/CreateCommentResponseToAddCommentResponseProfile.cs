using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
    public class CreateCommentResponseToAddCommentResponseProfile : Profile
    {
        public CreateCommentResponseToAddCommentResponseProfile()
        {
            CreateMap<CreateCommentResponse, AddCommentResponse>()
                .ForMember(x => x.Success, o => o.ResolveUsing(x => x.IsSuccess));
        }
    }
}
