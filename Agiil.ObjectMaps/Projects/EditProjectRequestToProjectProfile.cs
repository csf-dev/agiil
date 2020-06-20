using System;
using Agiil.Domain.Projects;
using AutoMapper;

namespace Agiil.ObjectMaps.Projects
{
    public class EditProjectRequestToProjectProfile : Profile
    {
        public EditProjectRequestToProjectProfile()
        {
            CreateMap<EditProjectRequest, Project>()
                .ForMember(x => x.Code, o => o.ResolveUsing(p => p.Code))
                .ForMember(x => x.Name, o => o.ResolveUsing(p => p.Name))
                .ForMember(x => x.Description, o => o.ResolveUsing(p => p.Description ?? String.Empty))
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}
