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
            var request = mapper.Map<CreateCommentRequest>(spec);
            var sourceResponse = commentCreator.Value.Create(request);

            var response = mapper.Map<AddCommentResponse>(sourceResponse);

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

            var model = new EditCommentModel {
                Comment = mapper.Map<CommentDto>(comment),
                Response = TempData.TryGet<Models.Tickets.EditCommentResponse>(EditCommentResponseKey),
                Specification = TempData.TryGet<EditCommentSpecification>(EditCommentSpecKey),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCommentSpecification spec)
        {
            var request = mapper.Map<EditCommentRequest>(spec);
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

            var responseModel = mapper.Map<Models.Tickets.EditCommentResponse>(response);
            TempData.Add(EditCommentResponseKey, responseModel);
            TempData.Add(EditCommentSpecKey, spec);

            return RedirectToAction(nameof(Edit), new { id = spec.CommentId?.Value });
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
