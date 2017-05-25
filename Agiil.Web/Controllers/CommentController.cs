using System;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using Agiil.Web.Services.Tickets;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class CommentController : ControllerBase
  {
    internal const string
      CommentSpecKey          = "New comment specification",
      CommentResponseKey      = "New comment response",
      EditCommentSpecKey      = "Edit comment specification",
      EditCommentResponseKey  = "Edit comment response";

    readonly Lazy<ICommentCreator> commentCreator;
    readonly Lazy<ICommentEditor> commentEditor;
    readonly Lazy<ICommentReader> commentReader;
    readonly CommentMapper mapper;

    [HttpPost]
    public ActionResult Add(AddCommentSpecification spec)
    {
      var request = GetCreationRequest(spec);
      var sourceResponse = commentCreator.Value.Create(request);

      var response = MapResponse(sourceResponse);

      TempData[CommentSpecKey] = (response != null && !response.Success)? spec : null;
      TempData[CommentResponseKey] = response;

      return RedirectToAction(nameof(TicketController.Index),
                              GetControllerName<TicketController>(),
                              new { id = spec.TicketId?.Value });
    }

    [HttpGet]
    public ActionResult Edit(IIdentity<Comment> id)
    {
      var comment = commentReader.Value.Read(id);

      if(ReferenceEquals(comment, null))
        return HttpNotFound();

      var model = GetEditCommentModel(comment);

      return View (model);
    }

    [HttpPost]
    public ActionResult Edit(EditCommentSpecification spec)
    {
      var request = MapRequest(spec);
      var response = commentEditor.Value.Edit(request);

      if(response.CommentDoesNotExist)
        return HttpNotFound();

      TempData.Clear();

      if(response.IsSuccess)
      {
        var comment = commentReader.Value.Read(spec.CommentId);
        return RedirectToAction(nameof(TicketController.Index),
                                GetControllerName<TicketController>(),
                                new { id = comment.Ticket.GetIdentity()?.Value });
      }

      var responseModel = MapEditResponse(response);
      TempData.Add(EditCommentResponseKey, responseModel);
      TempData.Add(EditCommentSpecKey, spec);

      return RedirectToAction(nameof(Edit), new { id = spec.CommentId?.Value });
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

    EditCommentRequest MapRequest(EditCommentSpecification spec)
    {
      if(ReferenceEquals(spec, null))
        return null;

      return new EditCommentRequest
      {
        CommentIdentity = spec.CommentId,
        Body = spec.Body,
      };
    }

    Models.Tickets.EditCommentResponse MapEditResponse(Domain.Tickets.EditCommentResponse response)
    {
      if(ReferenceEquals(response, null))
        return null;

      return new Models.Tickets.EditCommentResponse
      {
        BodyIsInvalid = response.BodyIsInvalid,
        UserDoesNotHavePermission = response.UserDoesNotHavePermission,
      };
    }

    EditCommentModel GetEditCommentModel(Comment comment)
    {
      var model = ModelFactory.GetModel<EditCommentModel>();
      model.Comment = mapper.Map(comment);
      model.Response = GetTempData<Models.Tickets.EditCommentResponse>(EditCommentResponseKey);
      model.Specification = GetTempData<EditCommentSpecification>(EditCommentSpecKey);
      return model;
    }

    public CommentController(Services.SharedModel.StandardPageModelFactory modelFactory,
                             Lazy<ICommentCreator> commentCreator,
                             Lazy<ICommentEditor> commentEditor,
                             Lazy<ICommentReader> commentReader,
                             CommentMapper mapper)
      : base(modelFactory)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(commentReader == null)
        throw new ArgumentNullException(nameof(commentReader));
      if(commentEditor == null)
        throw new ArgumentNullException(nameof(commentEditor));
      if(commentCreator == null)
        throw new ArgumentNullException(nameof(commentCreator));
      this.mapper = mapper;
      this.commentCreator = commentCreator;
      this.commentEditor = commentEditor;
      this.commentReader = commentReader;
    }
  }
}
