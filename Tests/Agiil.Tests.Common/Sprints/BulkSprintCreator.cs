using System;
using System.Collections.Generic;
using Agiil.Domain.Projects;
using Agiil.Domain.Sprints;
using AutoMapper;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Tests.Sprints
{
  public class BulkSprintCreator : IBulkSprintCreator
  {
    readonly IMapper mapper;
    readonly IRepository<Sprint> sprintsRepo;
    readonly ISprintFactory factory;
    readonly ICurrentProjectGetter projectReader;

    public void Create(IEnumerable<BulkSprintCreationSpecification> specs)
    {
      if(specs == null)
        throw new ArgumentNullException(nameof(specs));

      foreach(var spec in specs)
      {
        Create(spec);
      }
    }

    void Create(BulkSprintCreationSpecification spec)
    {
      if(ReferenceEquals(spec, null))
        return;

      var sprint = GetSprint(spec);
      sprintsRepo.Add(sprint);
    }

    Sprint GetSprint(BulkSprintCreationSpecification spec)
    {
      var sprint = factory.CreateSprint(spec.Name,
                                        projectReader.GetCurrentProject(),
                                        spec.StartDate,
                                        spec.EndDate);
      mapper.Map(spec, sprint);

      if(sprint.GetIdentity() == null)
      {
        sprint.GenerateIdentity();
      }

      return sprint;
    }

    public BulkSprintCreator(IMapper mapper,
                             IRepository<Sprint> sprintsRepo,
                             ISprintFactory factory,
                             ICurrentProjectGetter projectReader)
    {
      if(sprintsRepo == null)
        throw new ArgumentNullException(nameof(sprintsRepo));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(factory == null)
        throw new ArgumentNullException(nameof(factory));
      if(projectReader == null)
        throw new ArgumentNullException(nameof(projectReader));
      
      this.mapper = mapper;
      this.sprintsRepo = sprintsRepo;
      this.factory = factory;
      this.projectReader = projectReader;
    }
  }
}
