using System;
using Agiil.Domain.Projects;
using AutoMapper;

namespace Agiil.ObjectMaps.Projects
{
    public class CreateProjectRequestToProjectProfile : Profile
    {
        public CreateProjectRequestToProjectProfile()
        {
            CreateMap<CreateProjectRequest, Project>()
                .ForMember(x => x.Description, o => o.ResolveUsing(r => r.Description ?? String.Empty))
                .ForMember(x => x.NextAvailableTicketNumber, o => o.Ignore());
        }
    }
}
