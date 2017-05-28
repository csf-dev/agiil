using System;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
  public class SprintToSprintSummaryDtoProfile : Profile
  {
    public SprintToSprintSummaryDtoProfile()
    {
      CreateMap<Sprint,SprintSummaryDto>()
        .ForMember(x => x.Id, opts => opts.ResolveUsing<IdentityValueResolver>());
    }
  }
}
