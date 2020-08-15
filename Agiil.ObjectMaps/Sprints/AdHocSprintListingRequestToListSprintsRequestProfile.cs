using System;
using Agiil.Domain.Projects;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Sprints
{
  public class AdHocSprintListingRequestToListSprintsRequestProfile : Profile
  {
    public AdHocSprintListingRequestToListSprintsRequestProfile()
    {
      CreateMap<AdHocSprintListingRequest,ListSprintsRequest>()
        .ForMember(x => x.ShowOpenSprints, opts => opts.ResolveUsing(x => !x.ShowClosedSprints))
        .ForMember(x => x.Project, o => o.Ignore())
        .AfterMap((src, dest, ctx) => {
            dest.Project = ctx.Mapper.Resolve<IGetsCurrentProject>().GetCurrentProject()?.GetIdentity();
        })
        ;
    }
  }
}
