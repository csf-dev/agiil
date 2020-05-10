using System;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
    public class CommentController : Controller
    {
        internal const string
          CommentSpecKey = "New comment specification",
          CommentResponseKey = "New comment response",
          EditCommentSpecKey = "Edit comment specification",
          EditCommentResponseKey = "Edit comment response";

        readonly Lazy<ICommentCreator> commentCreator;
        readonly Lazy<ICommentEditor> commentEditor;
        readonly Lazy<ICommentReader> commentReader;
        readonly Lazy<ICommentDeleter> commentDeleter;
        readonly Lazy<IGetsTicketReference> referenceProvider;
        readonly IMapper mapper;

        [HttpPost]
        public ActionResult Add(AddCommentSpecification spec)
        {
            var request = GetCreationRequest(spec);
            var sourceResponse = commentCreator.Value.Create(request);

            var response = MapResponse(sourceResponse);

            TempData[CommentSpecKey] = (response != null && !response.Success) ? spec : null;
            TempData[CommentResponseKey] = response;

            return RedirectToAction(nameof(TicketController.Index),
                                    this.GetName<TicketController>(),
                                    new { id = referenceProvider.Value.GetTicketReference(spec.TicketId) });
        }

        [HttpPost]
        public ActionResult ConfirmDelete(IIdentity<Comment> id)
        {
            var comment = commentReader.Value.Read(id);

            if(ReferenceEquals(comment, null))
                return HttpNotFound();

            var model = new DeleteCommentModel();
            model.Comment = mapper.Map<CommentDto>(comment);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(IIdentity<Comment> id)
        {
            var comment = commentReader.Value.Read(id);

            if(ReferenceEquals(comment, null))
                return HttpNotFound();

            var ticketRef = comment.Ticket.GetTicketReference();

            var request = new DeleteCommentRequest { CommentId = id };
            var sourceResponse = commentDeleter.Value.Delete(request);

            if(!sourceResponse.IsSuccess)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);

            return RedirectToAction(nameof(TicketController.Index),
                                    this.GetName<TicketController>(),
                                    new { id = ticketRef });
        }

        [HttpGet]
        public ActionResult Edit(IIdentity<Comment> id)
        {
            var comment = commentReader.Value.Read(id);

            if(ReferenceEquals(comment, null))
                return HttpNotFound();

            var model = GetEditCommentModel(comment);

            return View(model);
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
                                        this.GetName<TicketController>(),
                                        new { id = comment.Ticket.GetTicketReference() });
            }

            var responseModel = MapEditResponse(response);
            TempData.Add(EditCommentResponseKey, responseModel);
            TempData.Add(EditCommentSpecKey, spec);

            return RedirectToAction(nameof(Edit), new { id = spec.CommentId?.Value });
        }

        // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
        CreateCommentRequest GetCreationRequest(AddCommentSpecification spec)
        {
            if(spec == null)
                return null;

            return new CreateCommentRequest {
                TicketId = spec.TicketId,
                Body = spec.Body,
            };
        }

        // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
        AddCommentResponse MapResponse(CreateCommentResponse source)
        {
            if(source == null)
                return null;

            return new AddCommentResponse {
                Success = source.IsSuccess,
                BodyIsInvalid = source.BodyIsInvalid
            };
        }

        // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
        EditCommentRequest MapRequest(EditCommentSpecification spec)
        {
            if(ReferenceEquals(spec, null))
                return null;

            return new EditCommentRequest {
                CommentIdentity = spec.CommentId,
                Body = spec.Body,
            };
        }

        // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
        Models.Tickets.EditCommentResponse MapEditResponse(Domain.Tickets.EditCommentResponse response)
        {
            if(ReferenceEquals(response, null))
                return null;

            return new Models.Tickets.EditCommentResponse {
                BodyIsInvalid = response.BodyIsInvalid,
                UserDoesNotHavePermission = response.UserDoesNotHavePermission,
            };
        }

        EditCommentModel GetEditCommentModel(Comment comment)
        {
            var model = new EditCommentModel();
            model.Comment = mapper.Map<CommentDto>(comment);
            model.Response = TempData.TryGet<Models.Tickets.EditCommentResponse>(EditCommentResponseKey);
            model.Specification = TempData.TryGet<EditCommentSpecification>(EditCommentSpecKey);
            return model;
        }

        public CommentController(Lazy<ICommentCreator> commentCreator,
                                 Lazy<ICommentEditor> commentEditor,
                                 Lazy<ICommentReader> commentReader,
                                 Lazy<ICommentDeleter> commentDeleter,
                                 Lazy<IGetsTicketReference> referenceProvider,
                                 IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.commentCreator = commentCreator ?? throw new ArgumentNullException(nameof(commentCreator));
            this.commentEditor = commentEditor ?? throw new ArgumentNullException(nameof(commentEditor));
            this.commentReader = commentReader ?? throw new ArgumentNullException(nameof(commentReader));
            this.commentDeleter = commentDeleter ?? throw new ArgumentNullException(nameof(commentDeleter));
            this.referenceProvider = referenceProvider ?? throw new ArgumentNullException(nameof(referenceProvider));
        }
    }
}
