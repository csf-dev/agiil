using System;
using Agiil.Domain.Projects;
using Agiil.Web.Models.Projects;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Projects
{
    public class ProjectToAvailableProjectModelProfile : Profile
    {
        public ProjectToAvailableProjectModelProfile()
        {
            CreateMap<Project, AvailableProjectModel>()
                .ForMember(x => x.Identity, o => o.ResolveUsing(p => p.GetIdentity()))
                .ForMember(x => x.Name, o => o.ResolveUsing(p => p.Name))
                .ForMember(x => x.Code, o => o.ResolveUsing(p => p.Code))
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}
