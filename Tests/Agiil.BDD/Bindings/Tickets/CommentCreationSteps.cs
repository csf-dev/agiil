using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;
using CSF.Entities;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class CommentCreationSteps
  {
    readonly ICommentController commentController;
    readonly IBulkCommentCreator commentCreator;
    readonly IFixture autoFixture;

    [When("the user adds a comment with the following specification:")]
    public void TheUserAddsACommentWithSpecification(Table commentProperties)
    {
      var spec = commentProperties.CreateInstance<AddCommentSpecification>();
      spec.TicketId = Identity.Parse<Ticket>(commentProperties.Rows[0].GetString("TicketId"));
      commentController.Add(spec);
    }

    [Given(@"ticket ID (\d+) has the following comments:")]
    public void ATicketHasComments(long ticketId, Table bulkComments)
    {
      var comments = bulkComments.CreateSet(() => autoFixture.Create<BulkCommentSpecification>());
      foreach(var comment in comments)
      {
        comment.TicketId = ticketId;
      }
      commentCreator.CreateComments(comments);
    }

    public CommentCreationSteps(ICommentController commentController,
                                IBulkCommentCreator commentCreator,
                                IFixture autoFixture)
    {
      if(autoFixture == null)
        throw new ArgumentNullException(nameof(autoFixture));
      if(commentCreator == null)
        throw new ArgumentNullException(nameof(commentCreator));
      if(commentController == null)
        throw new ArgumentNullException(nameof(commentController));
      this.commentController = commentController;
      this.commentCreator = commentCreator;
      this.autoFixture = autoFixture;
    }
  }
}
