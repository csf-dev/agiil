using System;
using CSF.Validation;
using CSF.Validation.Manifest;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Tickets
{
  public class CreateTicketValidatorFactory : ICreateTicketValidatorFactory
  {
    public IValidator GetValidator()
    {
      var manifest = GetManifest();

      return new ValidatorFactory().GetValidator(manifest);
    }

    IValidationManifest GetManifest()
    {
      var builder = ManifestBuilder.Create<CreateTicketRequest>();

      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<NotNullValueRule>(x => x.Title);
      builder.AddMemberRule<RegexMatchValueRule>(x => x.Title, c => {
        c.AddDependency<NotNullValueRule,CreateTicketRequest>(x => x.Title);
        c.Configure(r => r.Pattern = @"^\S+");
      });

      return builder.GetManifest();
    }
  }
}
