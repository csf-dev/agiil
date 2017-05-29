﻿using System;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Sprints
{
  public class CreateSprintValidatorFactory : ValidatorFactoryBase<CreateSprintRequest>
  {
    protected override void ConfigureManifest(IManifestBuilder<CreateSprintRequest> builder)
    {
      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<RegexMatchValueRule>(x => x.Name, c => {
        c.Configure(r => r.Pattern = @"^\S+");
      });
      builder.AddRule<EndDateMustNotBeBeforeStartDateRule>();
    }

    public CreateSprintValidatorFactory(IValidatorFactory validatorFactory) : base(validatorFactory) {}
  }
}