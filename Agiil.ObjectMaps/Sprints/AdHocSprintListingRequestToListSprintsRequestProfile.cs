using System;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
  public class AdHocSprintListingRequestToListSprintsRequestProfile : Profile
  {
    public AdHocSprintListingRequestToListSprintsRequestProfile()
    {
      CreateMap<AdHocSprintListingRequest,ListSprintsRequest>()
        .ForMember(x => x.ShowOpenSprints, opts => opts.ResolveUsing(x => !x.ShowClosedSprints))
        ;
    }
  }
}
