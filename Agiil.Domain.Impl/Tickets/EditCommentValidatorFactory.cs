using System;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Tickets
{
  public class EditCommentValidatorFactory : ValidatorFactoryBase<EditCommentRequest>
  {
    protected override void ConfigureManifest(IManifestBuilder<EditCommentRequest> builder)
    {
      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<NotNullValueRule>(x => x.CommentIdentity);
      builder.AddMemberRule<EntityMustExistRule<Comment>>(x => x.CommentIdentity, c => {
        c.Name(RuleNames.EntityMustExist);
      });
      builder.AddMemberRule<MustBeLoggedInAsCommentAuthorRule>(x => x.CommentIdentity, c => {
        c.Name(RuleNames.Comments.EditingPermissionDenied);
      });
      builder.AddMemberRule<NotNullValueRule>(x => x.Body);
      builder.AddMemberRule<RegexMatchValueRule>(x => x.Body, c => {
        c.Configure(r => r.Pattern = @"^\S+");
      });
    }

    public EditCommentValidatorFactory(IValidatorFactory validatorFactory) : base(validatorFactory) {}
  }
}
