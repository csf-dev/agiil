using System;
using Agiil.Domain.Sprints;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
    public class EditSprintRequestToSprintProfile : Profile
    {
        public EditSprintRequestToSprintProfile()
        {
            CreateMap<EditSprintRequest, Sprint>()
                .ForMember(x => x.Project, o => o.Ignore())
                .ForMember(x => x.CreationDate, o => o.Ignore())
                ;
        }
    }
}
