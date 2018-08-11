using System;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Sprints;
using Agiil.Web.Models.Tickets;
using Agiil.Web.Services.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class TicketController : Controller
  {
    internal const string 
      EditTicketResponseKey = "Edit ticket response",
      EditTicketSpecKey = "Edit ticket specification",
      SuccessfulEditKey = "Successful edit";

    readonly ITicketDetailService ticketDetailService;
    readonly Lazy<IHandlesEditTicketRequest> editor;
    readonly Lazy<IGetsEditTicketModel> editTicketModelFactory;
    readonly IMapper mapper;

    public ActionResult Index(IIdentity<Ticket> id)
    {
      var ticket = ticketDetailService.GetTicket(id);

      if(ReferenceEquals(ticket, null))
        return HttpNotFound();

      var model = GetViewTicketModel(ticket);

      return View (model);
    }

    [HttpGet]
    public ActionResult Edit(IIdentity<Ticket> id)
    {
      var ticket = ticketDetailService.GetTicket(id);

      if(ReferenceEquals(ticket, null))
        return HttpNotFound();

      var editModelFactory = editTicketModelFactory.Value;
      var model = editModelFactory.GetEditTicketModel(ticket);

      return View (model);
    }

    [HttpPost]
    public ActionResult Edit(EditTicketSpecification spec)
    {
      var request = mapper.Map<EditTicketRequest>(spec);
      var response = editor.Value.Edit(request);

      if(response.IdentityIsInvalid)
        return HttpNotFound();

      TempData.Clear();

      if(response.IsSuccess)
      {
        TempData.Add(SuccessfulEditKey, true);
        return RedirectToAction(nameof(Index), new { id = spec.Identity?.Value });
      }

      var responseModel = mapper.Map<Models.Tickets.EditTicketResponse>(response);
      TempData.Add(EditTicketResponseKey, responseModel);
      TempData.Add(EditTicketSpecKey, spec);

      return RedirectToAction(nameof(Edit), new { id = spec.Identity?.Value });
    }

    TicketDetailModel GetViewTicketModel(Ticket ticket)
    {
      var model = new TicketDetailModel();
      model.Ticket = mapper.Map<TicketDetailDto>(ticket);
      model.AddCommentSpecification = TempData.TryGet<AddCommentSpecification>(CommentController.CommentSpecKey);
      model.AddCommentResponse = TempData.TryGet<AddCommentResponse>(CommentController.CommentResponseKey);
      return model;
    }

    public TicketController(ITicketDetailService ticketDetailService,
                            Lazy<IHandlesEditTicketRequest> editor,
                            Lazy<IGetsEditTicketModel> editTicketModelFactory,
                            IMapper mapper)
    {
      if(editTicketModelFactory == null)
        throw new ArgumentNullException(nameof(editTicketModelFactory));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(editor == null)
        throw new ArgumentNullException(nameof(editor));
      if(ticketDetailService == null)
        throw new ArgumentNullException(nameof(ticketDetailService));
      
      this.mapper = mapper;
      this.ticketDetailService = ticketDetailService;
      this.editor = editor;
      this.editTicketModelFactory = editTicketModelFactory;
    }
  }
}
