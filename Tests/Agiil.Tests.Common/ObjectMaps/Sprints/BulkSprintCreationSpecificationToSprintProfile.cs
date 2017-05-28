using System;
using Agiil.Domain.Projects;
using Agiil.Domain.Sprints;
using Agiil.ObjectMaps;
using Agiil.Tests.Sprints;
using AutoMapper;

namespace Agiil.Tests.ObjectMaps.Sprints
{
  public class BulkSprintCreationSpecificationToSprintProfile : Profile
  {
    public BulkSprintCreationSpecificationToSprintProfile()
    {
      CreateMap<BulkSprintCreationSpecification,Sprint>()
        .AfterMap((spec, sprint) => {
          sprint.SetIdentityValue(spec.Id);
        });
    }
  }
}
