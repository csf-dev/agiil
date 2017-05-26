using System;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
  public class CreateSprintResponseToNewSprintResultProfile : Profile
  {
    public CreateSprintResponseToNewSprintResultProfile()
    {
      CreateMap<CreateSprintResponse,NewSprintResult>();
    }
  }
}
