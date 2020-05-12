using System;
using Agiil.Domain.Sprints;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.ObjectMaps.Sprints
{
  public class EditSprintSpecificationToEditSprintRequestProfile : Profile
  {
    public EditSprintSpecificationToEditSprintRequestProfile()
    {
      CreateMap<EditSprintSpecification,EditSprintRequest>()
        .ForMember(x => x.SprintIdentity, opts => opts.ResolveUsing<CreateIdentityResolver<Sprint>, long>(x => x.Id));
    }
  }
}
