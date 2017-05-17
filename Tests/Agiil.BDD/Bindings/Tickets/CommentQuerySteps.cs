using System;
using Agiil.Tests.Tickets;
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

    public CommentQuerySteps(ICommentQueryController commentQuery)
    {
      if(commentQuery == null)
        throw new ArgumentNullException(nameof(commentQuery));
      this.commentQuery = commentQuery;
    }
  }
}
