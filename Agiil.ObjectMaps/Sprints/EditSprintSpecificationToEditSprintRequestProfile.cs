using System;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
  public class EditSprintSpecificationToEditSprintRequestProfile : Profile
  {
    public EditSprintSpecificationToEditSprintRequestProfile(CreateIdentityResolver<Sprint> resolver)
    {
      CreateMap<EditSprintSpecification,EditSprintRequest>()
        .ForMember(x => x.SprintIdentity, opts => opts.ResolveUsing(resolver, x => x.Id));
    }
  }
}
