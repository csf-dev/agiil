using System;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
  public class EditSprintResponseToWebEditSprintResponseProfile : Profile
  {
    public EditSprintResponseToWebEditSprintResponseProfile()
    {
      CreateMap<Domain.Sprints.EditSprintResponse, Web.Models.Sprints.EditSprintResponse>();
    }
  }
}
