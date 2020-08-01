using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
    public class AddCommentSpecificationToCreateCommentRequestProfile : Profile
    {
        public AddCommentSpecificationToCreateCommentRequestProfile()
        {
            CreateMap<AddCommentSpecification,CreateCommentRequest>();
        }
    }
}
