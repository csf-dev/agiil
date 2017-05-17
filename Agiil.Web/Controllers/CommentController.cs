using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class CommentController : ControllerBase
  {
    internal const string
      CommentSpecKey = "New comment specification",
      CommentResponseKey = "New comment response";

    readonly ICommentCreator commentCreator;

    [HttpPost]
    public ActionResult Add(AddCommentSpecification spec)
    {
      var request = GetCreationRequest(spec);
      var sourceResponse = commentCreator.Create(request);

      var response = MapResponse(sourceResponse);

      TempData[CommentSpecKey] = (response != null && !response.Success)? spec : null;
      TempData[CommentResponseKey] = response;

      return RedirectToAction(nameof(TicketController.Index),
                              GetControllerName<TicketController>(),
                              new { id = spec.TicketId?.Value });
    }

    CreateCommentRequest GetCreationRequest(AddCommentSpecification spec)
    {
      if(spec == null)
        return null;

      return new CreateCommentRequest
      {
        TicketId = spec.TicketId,
        Body = spec.Body,
      };
    }

    AddCommentResponse MapResponse(CreateCommentResponse source)
    {
      if(source == null)
        return null;

      return new AddCommentResponse
      {
        Success = source.IsSuccess,
        BodyIsInvalid = source.BodyIsInvalid
      };
    }

    public CommentController(Services.SharedModel.StandardPageModelFactory modelFactory,
                             ICommentCreator commentCreator)
      : base(modelFactory)
    {
      if(commentCreator == null)
        throw new ArgumentNullException(nameof(commentCreator));
      this.commentCreator = commentCreator;
    }
  }
}
