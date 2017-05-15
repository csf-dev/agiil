using System;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Tickets
{
  public class EditTicketTitleAndDescriptionValidatorFactory
    : ValidatorFactoryBase<EditTicketTitleAndDescriptionRequest>, IEditTicketTitleAndDescriptionValidatorFactory
  {
    protected override void ConfigureManifest(IManifestBuilder<EditTicketTitleAndDescriptionRequest> builder)
    {
      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<EntityMustExistRule<Ticket>>(x => x.Identity);
      builder.AddMemberRule<NotNullValueRule>(x => x.Title);
      builder.AddMemberRule<RegexMatchValueRule>(x => x.Title, c => {
        c.AddDependency<NotNullValueRule,CreateTicketRequest>(x => x.Title);
        c.Configure(r => r.Pattern = @"^\S+");
      });
    }

    public EditTicketTitleAndDescriptionValidatorFactory(IValidatorFactory factory) : base(factory) {}
  }
}
