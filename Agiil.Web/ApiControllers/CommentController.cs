using System;
using System.Net;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.ApiControllers
{
    public class CommentController : ApiController
    {
        readonly Lazy<ICommentCreator> commentCreator;
        readonly Lazy<ICommentEditor> commentEditor;
        readonly IMapper mapper;

        public AddCommentResponse Put(AddCommentSpecification spec)
        {
            var request = mapper.Map<CreateCommentRequest>(spec);
            var sourceResponse = commentCreator.Value.Create(request);

            return mapper.Map<AddCommentResponse>(sourceResponse);
        }

        public Models.Tickets.EditCommentResponse Post(EditCommentSpecification spec)
        {
            if(spec == null)
                throw new ArgumentNullException(nameof(spec));

            var request = mapper.Map<EditCommentRequest>(spec);
            var response = commentEditor.Value.Edit(request);

            if(response.CommentDoesNotExist)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return mapper.Map<Models.Tickets.EditCommentResponse>(response);
        }

        public CommentController(Lazy<ICommentCreator> commentCreator,
                                 Lazy<ICommentEditor> commentEditor,
                                 IMapper mapper)
        {
            this.commentCreator = commentCreator ?? throw new ArgumentNullException(nameof(commentCreator));
            this.commentEditor = commentEditor ?? throw new ArgumentNullException(nameof(commentEditor));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
