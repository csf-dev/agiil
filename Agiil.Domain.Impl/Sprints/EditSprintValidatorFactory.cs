using System;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Sprints
{
  public class EditSprintValidatorFactory : ValidatorFactoryBase<EditSprintRequest>
  {
    protected override void ConfigureManifest(IManifestBuilder<EditSprintRequest> builder)
    {
      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<NotNullValueRule>(x => x.SprintIdentity);
      builder.AddMemberRule<EntityMustExistRule<Sprint>>(x => x.SprintIdentity);
      builder.AddMemberRule<RegexMatchValueRule>(x => x.Name, c => {
        c.Configure(r => r.Pattern = @"^\S+");
      });
      builder.AddRule<EndDateMustNotBeBeforeStartDateRule>();
    }

    public EditSprintValidatorFactory(IValidatorFactory validatorFactory) : base(validatorFactory) {}
  }
}
