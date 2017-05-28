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
  public class TicketController : ControllerBase
  {
    const string 
      EditTicketResponseKey = "Edit ticket response",
      EditTicketSpecKey = "Edit ticket specification",
      SuccessfulEditKey = "Successful edit";

    readonly ITicketDetailService ticketDetailService;
    readonly Lazy<ITicketEditor> editor;
    readonly Lazy<ISprintLister> sprintLister;

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
      var request = Mapper.Map<EditTicketRequest>(spec);
      var response = editor.Value.Edit(request);

      if(response.IdentityIsInvalid)
        return HttpNotFound();

      TempData.Clear();

      if(response.IsSuccess)
      {
        TempData.Add(SuccessfulEditKey, true);
        return RedirectToAction(nameof(Index), new { id = spec.Identity?.Value });
      }

      var responseModel = Mapper.Map<Models.Tickets.EditTicketResponse>(response);
      TempData.Add(EditTicketResponseKey, responseModel);
      TempData.Add(EditTicketSpecKey, spec);

      return RedirectToAction(nameof(Edit), new { id = spec.Identity?.Value });
    }

    TicketDetailModel GetViewTicketModel(Ticket ticket)
    {
      var model = ModelFactory.GetModel<TicketDetailModel>();
      model.Ticket = Mapper.Map<TicketDetailDto>(ticket);
      model.AddCommentSpecification = GetTempData<AddCommentSpecification>(CommentController.CommentSpecKey);
      model.AddCommentResponse = GetTempData<AddCommentResponse>(CommentController.CommentResponseKey);
      return model;
    }

    void PopulateCreateCommentModelProperties(TicketDetailModel model)
    {
      if(model == null)
        throw new ArgumentNullException(nameof(model));

      model.AddCommentSpecification = GetTempData<AddCommentSpecification>(CommentController.CommentSpecKey);
      model.AddCommentResponse = GetTempData<AddCommentResponse>(CommentController.CommentResponseKey);
    }

    EditTicketModel GetEditTicketModel(Ticket ticket)
    {
      var model = ModelFactory.GetModel<EditTicketModel>();
      model.Ticket = Mapper.Map<TicketDetailDto>(ticket);
      model.Response = GetTempData<Models.Tickets.EditTicketResponse>(EditTicketResponseKey);
      model.Specification = GetTempData<EditTicketSpecification>(EditTicketSpecKey);
      model.AvailableSprints = sprintLister
        .Value
        .GetSprints()
        .Select(x => Mapper.Map<SprintSummaryDto>(x))
        .ToList();
      return model;
    }

    public TicketController(ITicketDetailService ticketDetailService,
                            Lazy<ITicketEditor> editor,
                            Lazy<ISprintLister> sprintLister,
                            ControllerBaseDependencies baseDeps)
      : base(baseDeps)
    {
      if(sprintLister == null)
        throw new ArgumentNullException(nameof(sprintLister));
      if(editor == null)
        throw new ArgumentNullException(nameof(editor));
      if(ticketDetailService == null)
        throw new ArgumentNullException(nameof(ticketDetailService));
      
      this.ticketDetailService = ticketDetailService;
      this.editor = editor;
      this.sprintLister = sprintLister;
    }
  }
}
