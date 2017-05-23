using System;
using Agiil.Domain.Validation;
using CSF.Entities;
using CSF.Validation;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Tickets
{
  public class CreateCommentValidatorFactory : ValidatorFactoryBase<CreateCommentRequest>
  {
    protected override void ConfigureManifest(IManifestBuilder<CreateCommentRequest> builder)
    {
      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<NotNullValueRule>(x => x.TicketId);
      builder.AddMemberRule<EntityMustExistRule<Ticket>>(x => x.TicketId);
      builder.AddMemberRule<NotNullValueRule>(x => x.Body);
      builder.AddMemberRule<RegexMatchValueRule>(x => x.Body, c => {
        c.Configure(r => r.Pattern = @"^\S+");
      });
    }

    public CreateCommentValidatorFactory(IValidatorFactory factory) : base(factory) {}
  }
}
