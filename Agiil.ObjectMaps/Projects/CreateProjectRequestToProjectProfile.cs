using System;
using Agiil.Domain.Projects;
using AutoMapper;

namespace Agiil.ObjectMaps.Projects
{
    public class CreateProjectRequestToProjectProfile : Profile
    {
        public CreateProjectRequestToProjectProfile()
        {
            CreateMap<CreateProjectRequest, Project>();
        }
    }
}
