using System;
using Agiil.Domain.Projects;
using Agiil.Web.Models.Projects;
using AutoMapper;

namespace Agiil.ObjectMaps.Projects
{
    public class EditProjectModelToEditProjectRequestProfile : Profile
    {
        public EditProjectModelToEditProjectRequestProfile()
        {
            CreateMap<EditProjectModel,EditProjectRequest>();
        }
    }
}
