using System;
using System.Net;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.ApiControllers
{
  public class CommentController : ApiController
  {
    readonly Lazy<ICommentCreator> commentCreator;
    readonly Lazy<ICommentEditor> commentEditor;

    public AddCommentResponse Put(AddCommentSpecification spec)
    {
      var request = GetCreationRequest(spec);
      var sourceResponse = commentCreator.Value.Create(request);

      return MapResponse(sourceResponse);
    }

    public Models.Tickets.EditCommentResponse Post(EditCommentSpecification spec)
    {
      if(spec == null)
      {
        throw new ArgumentNullException(nameof(spec));
      }

      // TODO: Switch this over to use an IMapper
      var request = new EditCommentRequest
      {
        CommentIdentity = spec.CommentId,
        Body = spec.Body,
      };
      var response = commentEditor.Value.Edit(request);

      if(response.CommentDoesNotExist)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      // TODO: Switch this over to use an IMapper
      return new Models.Tickets.EditCommentResponse
      {
        BodyIsInvalid = response.BodyIsInvalid,
        UserDoesNotHavePermission = response.UserDoesNotHavePermission,
        Success = response.IsSuccess
      };
    }

    // TODO: Switch this over to use an IMapper
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

    // TODO: Switch this over to use an IMapper
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

    public CommentController(Lazy<ICommentCreator> commentCreator,
                             Lazy<ICommentEditor> commentEditor)
    {
      if(commentEditor == null)
        throw new ArgumentNullException(nameof(commentEditor));
      if(commentCreator == null)
        throw new ArgumentNullException(nameof(commentCreator));
      this.commentCreator = commentCreator;
      this.commentEditor = commentEditor;
    }
  }
}
