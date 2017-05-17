using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using CSF.Entities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class CommentCreationSteps
  {
    readonly ICommentController commentController;

    [When("the user adds a comment with the following specification:")]
    public void TheUserAddsACommentWithSpecification(Table commentProperties)
    {
      var spec = commentProperties.CreateInstance<AddCommentSpecification>();
      spec.TicketId = Identity.Parse<Ticket>(commentProperties.Rows[0].GetString("TicketId"));
      commentController.Add(spec);
    }

    public CommentCreationSteps(ICommentController commentController)
    {
      if(commentController == null)
        throw new ArgumentNullException(nameof(commentController));
      this.commentController = commentController;
    }
  }
}
