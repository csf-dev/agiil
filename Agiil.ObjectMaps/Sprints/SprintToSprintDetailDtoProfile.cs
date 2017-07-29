using System;
using Agiil.Domain.Sprints;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
  public class SprintToSprintDetailDtoProfile : Profile
  {
    public SprintToSprintDetailDtoProfile()
    {
      CreateMap<Sprint,SprintDetailDto>()
        .ForMember(x => x.Id, opts => opts.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.ProjectName, opts => opts.ResolveUsing(x => x.Project?.Name))
        .ForMember(x => x.ProjectCode, opts => opts.ResolveUsing(x => x.Project?.Code))
        ;
    }
  }
}
