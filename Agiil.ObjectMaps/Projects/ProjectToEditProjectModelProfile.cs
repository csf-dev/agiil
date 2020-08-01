using System;
using Agiil.Domain.Projects;
using Agiil.Web.Models.Projects;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Projects
{
    public class ProjectToEditProjectModelProfile : Profile
    {
        public ProjectToEditProjectModelProfile()
        {
            CreateMap<Project, EditProjectModel>()
                .ForMember(x => x.Identity, o => o.ResolveUsing(p => p.GetIdentity()))
                .ForMember(x => x.Request, o => o.Ignore())
                .ForMember(x => x.Response, o => o.Ignore())
                ;
        }
    }
}
