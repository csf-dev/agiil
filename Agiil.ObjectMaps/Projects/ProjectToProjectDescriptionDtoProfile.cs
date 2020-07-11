using System;
using Agiil.Domain.Projects;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Projects;
using AutoMapper;

namespace Agiil.ObjectMaps.Projects
{
    public class ProjectToProjectDescriptionDtoProfile : Profile
    {
        public ProjectToProjectDescriptionDtoProfile()
        {
            CreateMap<Project, ProjectDescriptionDto>()
                .ForMember(x => x.DescriptionHtml, o => o.ResolveUsing<MarkdownToHtmlResolver, string>(x => x.Description));
        }
    }
}
