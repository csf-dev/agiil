﻿using System;
using Agiil.Domain.Validation;
using Agiil.Domain.Projects;
using CSF.Data.Entities;
using CSF.Data;
using CSF.Validation;

namespace Agiil.Domain.Sprints
{
  public class SprintCreator : ISprintCreator
  {
    readonly IValidatorFactory<CreateSprintRequest> validatorFactory;
    readonly ICurrentProjectGetter projectGetter;
    readonly IRepository<Sprint> sprintRepo;
    readonly ITransactionCreator transactionFactory;
    readonly IResponseFactory<CreateSprintResponse> responseFactory;
    readonly ISprintFactory sprintFactory;

    public CreateSprintResponse Create(CreateSprintRequest request)
    {
      var validationResult = ValidateRequest(request);
      var response = responseFactory.GetResponse(validationResult);

      if(!validationResult.IsSuccess)
        return response;

      Sprint sprint;

      using(var trans = transactionFactory.BeginTransaction())
      {
        var project = projectGetter.GetCurrentProject();
        if(project == null)
        {
          response.ProjectDoesNotExist = true;
          return response;
        }

        sprint = CreateSprint(request, project);
        sprintRepo.Add(sprint);
        trans.Commit();

        response.Sprint = sprint;
      }

      return response;
    }

    IValidationResult ValidateRequest(CreateSprintRequest request)
    {
      var validator = validatorFactory.GetValidator();
      return validator.Validate(request);
    }

    Sprint CreateSprint(CreateSprintRequest request, Project project)
    {
      return sprintFactory.CreateSprint(request.Name, project, request.StartDate, request.EndDate);
    }

    public SprintCreator(IValidatorFactory<CreateSprintRequest> validatorFactory,
                         ICurrentProjectGetter projectGetter,
                         IRepository<Sprint> sprintRepo,
                         ITransactionCreator transactionFactory,
                         IResponseFactory<CreateSprintResponse> responseFactory,
                         ISprintFactory sprintFactory)
    {
      if(sprintFactory == null)
        throw new ArgumentNullException(nameof(sprintFactory));
      if(responseFactory == null)
        throw new ArgumentNullException(nameof(responseFactory));
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(sprintRepo == null)
        throw new ArgumentNullException(nameof(sprintRepo));
      if(projectGetter == null)
        throw new ArgumentNullException(nameof(projectGetter));
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));
      this.sprintFactory = sprintFactory;
      this.responseFactory = responseFactory;
      this.transactionFactory = transactionFactory;
      this.sprintRepo = sprintRepo;
      this.projectGetter = projectGetter;
      this.validatorFactory = validatorFactory;
    }
  }
}
