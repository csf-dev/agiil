using System;
using System.Linq;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class CommentQuerySteps
  {
    readonly ICommentQueryController commentQuery;

    [Then("a comment should exist with the following properties:")]
    public void ACommentShouldExistMatchingCriteria(Table criteriaTable)
    {
      var criteria = criteriaTable.CreateInstance<CommentSearchCriteria>();
      var exists = commentQuery.DoesCommentExist(criteria);
      Assert.IsTrue(exists, "The comment exists");
    }

    [Then("no comment should exist with the following properties:")]
    public void NoCommentShouldExistMatchingCriteria(Table criteriaTable)
    {
      var criteria = criteriaTable.CreateInstance<CommentSearchCriteria>();
      var exists = commentQuery.DoesCommentExist(criteria);
      Assert.IsFalse(exists, "The comment does not exist");
    }

    [Then("the following comments should be displayed in order:")]
    public void TheFollowingCommentsShouldBeDisplayedInOrder(Table commentTable)
    {
      if(commentTable == null)
        throw new ArgumentNullException(nameof(commentTable));

      var comments = commentTable.CreateSet<CommentDto>().ToList();
      commentQuery.VerifyThatCommentsAreListedInOrder(comments);
    }

    public CommentQuerySteps(ICommentQueryController commentQuery)
    {
      if(commentQuery == null)
        throw new ArgumentNullException(nameof(commentQuery));
      this.commentQuery = commentQuery;
    }
  }
}
