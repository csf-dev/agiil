using System;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Tickets
{
  public class CreateTicketValidatorFactory : ValidatorFactoryBase<CreateTicketRequest>
  {
    protected override void ConfigureManifest(IManifestBuilder<CreateTicketRequest> builder)
    {
      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<NotNullValueRule>(x => x.Title);
      builder.AddMemberRule<RegexMatchValueRule>(x => x.Title, c => {
        c.AddDependency<NotNullValueRule,CreateTicketRequest>(x => x.Title);
        c.Configure(r => r.Pattern = @"^\S+");
      });
    }

    public CreateTicketValidatorFactory(IValidatorFactory validatorFactory) : base(validatorFactory) {}
  }
}
