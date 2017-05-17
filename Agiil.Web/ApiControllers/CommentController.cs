using System;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;

namespace Agiil.Web.ApiControllers
{
  public class CommentController : ApiController
  {
    readonly Lazy<ICommentCreator> commentCreator;

    public AddCommentResponse Put(AddCommentSpecification spec)
    {
      var request = GetCreationRequest(spec);
      var sourceResponse = commentCreator.Value.Create(request);

      return MapResponse(sourceResponse);
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

    public CommentController(Lazy<ICommentCreator> commentCreator)
    {
      if(commentCreator == null)
        throw new ArgumentNullException(nameof(commentCreator));
      this.commentCreator = commentCreator;
    }
  }
}
