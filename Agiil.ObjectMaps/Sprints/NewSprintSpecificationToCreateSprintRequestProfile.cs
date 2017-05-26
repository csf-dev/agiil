using System;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
  public class NewSprintSpecificationToCreateSprintRequestProfile : Profile
  {
    public NewSprintSpecificationToCreateSprintRequestProfile()
    {
      CreateMap<NewSprintSpecification,CreateSprintRequest>();
    }
  }
}
