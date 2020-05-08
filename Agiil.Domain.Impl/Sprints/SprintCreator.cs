using System;
using Agiil.Domain.Validation;
using Agiil.Domain.Projects;
using CSF.ORM;
using CSF.Validation;

namespace Agiil.Domain.Sprints
{
  public class SprintCreator : ISprintCreator
  {
    readonly ICreatesValidators<CreateSprintRequest> validatorFactory;
    readonly ICurrentProjectGetter projectGetter;
    readonly IEntityData sprintRepo;
    readonly IGetsTransaction transactionFactory;
    readonly IResponseFactory<CreateSprintResponse> responseFactory;
    readonly ISprintFactory sprintFactory;

    public CreateSprintResponse Create(CreateSprintRequest request)
    {
      var validationResult = ValidateRequest(request);
      var response = responseFactory.GetResponse(validationResult);

      if(!validationResult.IsSuccess)
        return response;

      Sprint sprint;

      using(var trans = transactionFactory.GetTransaction())
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

    public SprintCreator(ICreatesValidators<CreateSprintRequest> validatorFactory,
                         ICurrentProjectGetter projectGetter,
                         IEntityData sprintRepo,
                         IGetsTransaction transactionFactory,
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
