using System;
using Agiil.Domain.Validation;
using AutoMapper;
using CSF.ORM;
using CSF.Validation;

namespace Agiil.Domain.Sprints
{
  public class SprintEditor : ISprintEditor
  {
    readonly IEntityData sprintRepo;
    readonly IGetsTransaction transactionFactory;
    readonly ICreatesValidators<EditSprintRequest> validatorFactory;
    readonly Func<IValidationResult, Sprint, EditSprintResponse> responseCreator;
    readonly IMapper mapper;

    public EditSprintResponse Edit(EditSprintRequest request)
    {
      var validationResult = ValidateRequest(request);
      if(!validationResult.IsSuccess)
        return responseCreator(validationResult, null);

      Sprint sprint;

      using(var trans = transactionFactory.GetTransaction())
      {
        sprint = sprintRepo.Get(request.SprintIdentity);
        mapper.Map(request, sprint);
        sprintRepo.Update(sprint);
        trans.Commit();
      }

      return responseCreator(validationResult, sprint);
    }

    IValidationResult ValidateRequest(EditSprintRequest request)
    {
      var validator = validatorFactory.GetValidator();
      return validator.Validate(request);
    }

    public SprintEditor(IEntityData sprintRepo,
                        IGetsTransaction transactionFactory,
                        ICreatesValidators<EditSprintRequest> validatorFactory,
                        Func<IValidationResult, Sprint, EditSprintResponse> responseCreator,
                        IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(responseCreator == null)
        throw new ArgumentNullException(nameof(responseCreator));
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(sprintRepo == null)
        throw new ArgumentNullException(nameof(sprintRepo));

      this.mapper = mapper;
      this.responseCreator = responseCreator;
      this.validatorFactory = validatorFactory;
      this.transactionFactory = transactionFactory;
      this.sprintRepo = sprintRepo;
    }
  }
}
