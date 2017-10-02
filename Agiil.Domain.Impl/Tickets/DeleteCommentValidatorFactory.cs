using System;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Tickets
{
  public class DeleteCommentValidatorFactory : ValidatorFactoryBase<DeleteCommentRequest>
  {
    protected override void ConfigureManifest(IManifestBuilder<DeleteCommentRequest> builder)
    {
      builder.AddRule<NotNullRule>();
      builder.AddMemberRule<NotNullValueRule>(x => x.CommentId);
      builder.AddMemberRule<EntityMustExistRule<Comment>>(x => x.CommentId, c => {
        c.Name(RuleNames.EntityMustExist);
      });
      builder.AddMemberRule<MustBeLoggedInAsCommentAuthorRule>(x => x.CommentId, c => {
        c.Name(RuleNames.Comments.DeletePermissionDenied);
      });
    }

    public DeleteCommentValidatorFactory(IValidatorFactory factory) : base(factory) {}
  }
}
