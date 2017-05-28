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
    public BulkSprintCreationSpecificationToSprintProfile(GetEntityByIdentityValueResolver<Project> projectResolver)
    {
      if(projectResolver == null)
        throw new ArgumentNullException(nameof(projectResolver));
      
      CreateMap<BulkSprintCreationSpecification,Sprint>()
        .AfterMap((spec, sprint) => {
          sprint.SetIdentityValue(spec.Id);
        });
    }
  }
}
