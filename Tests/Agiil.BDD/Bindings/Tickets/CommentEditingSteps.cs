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
  public class CommentEditingSteps
  {
    readonly ICommentController controller;

    [When("the user submits a request to edit a comment with the following specification:")]
    public void WhenTheUserSubmitsARequestToEditAComment(Table spec)
    {
      var request = spec.CreateInstance<EditCommentSpecification>();
      request.CommentId = Identity.Create<Comment>(spec.Rows[0].GetInt64(nameof(EditCommentSpecification.CommentId)));
      controller.Edit(request);
    }

    public CommentEditingSteps(ICommentController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      this.controller = controller;
    }
  }
}
