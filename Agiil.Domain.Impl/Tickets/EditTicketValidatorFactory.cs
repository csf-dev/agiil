﻿using System;
using Agiil.Domain.Sprints;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Tickets
{
  public class EditTicketValidatorFactory
    : ValidatorFactoryBase<EditTicketRequest>
  {
    protected override void ConfigureManifest(IManifestBuilder<EditTicketRequest> builder)
    {
      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<NotNullValueRule>(x => x.Identity);
      builder.AddMemberRule<EntityMustExistRule<Ticket>>(x => x.Identity);
      builder.AddMemberRule<NotNullValueRule>(x => x.Title);
      builder.AddMemberRule<RegexMatchValueRule>(x => x.Title, c => {
        c.Configure(r => r.Pattern = @"^\S+");
      });
      builder.AddMemberRule<EntityMustExistRule<Sprint>>(x => x.SprintIdentity);
    }

    public EditTicketValidatorFactory(IValidatorFactory factory) : base(factory) {}
  }
}