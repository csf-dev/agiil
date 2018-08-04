using System;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Sprints;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class TicketController : Controller
  {
    const string 
      EditTicketResponseKey = "Edit ticket response",
      EditTicketSpecKey = "Edit ticket specification",
      SuccessfulEditKey = "Successful edit";

    readonly ITicketDetailService ticketDetailService;
    readonly Lazy<IHandlesEditTicketRequest> editor;
    readonly Lazy<ISprintLister> sprintLister;
    readonly Lazy<ITicketTypeProvider> typeProvider;
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

      var model = GetEditTicketModel(ticket);

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

    void PopulateCreateCommentModelProperties(TicketDetailModel model)
    {
      if(model == null)
        throw new ArgumentNullException(nameof(model));

      model.AddCommentSpecification = TempData.TryGet<AddCommentSpecification>(CommentController.CommentSpecKey);
      model.AddCommentResponse = TempData.TryGet<AddCommentResponse>(CommentController.CommentResponseKey);
    }

    EditTicketModel GetEditTicketModel(Ticket ticket)
    {
      var model = new EditTicketModel();
      model.Ticket = mapper.Map<TicketDetailDto>(ticket);
      model.Response = TempData.TryGet<Models.Tickets.EditTicketResponse>(EditTicketResponseKey);
      model.Specification = TempData.TryGet<EditTicketSpecification>(EditTicketSpecKey);
      model.AvailableSprints = sprintLister
        .Value
        .GetSprints()
        .Select(x => mapper.Map<SprintSummaryDto>(x))
        .ToList();
      model.AvailableTicketTypes = typeProvider
        .Value
        .GetTicketTypes()
        .Select(x => mapper.Map<TicketTypeDto>(x))
        .ToList();
      
      return model;
    }

    public TicketController(ITicketDetailService ticketDetailService,
                            Lazy<IHandlesEditTicketRequest> editor,
                            Lazy<ISprintLister> sprintLister,
                            Lazy<ITicketTypeProvider> typeProvider,
                           IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(typeProvider == null)
        throw new ArgumentNullException(nameof(typeProvider));
      if(sprintLister == null)
        throw new ArgumentNullException(nameof(sprintLister));
      if(editor == null)
        throw new ArgumentNullException(nameof(editor));
      if(ticketDetailService == null)
        throw new ArgumentNullException(nameof(ticketDetailService));
      
      this.mapper = mapper;
      this.ticketDetailService = ticketDetailService;
      this.editor = editor;
      this.sprintLister = sprintLister;
      this.typeProvider = typeProvider;
    }
  }
}
