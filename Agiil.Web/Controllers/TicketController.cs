using System;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Services.Tickets;
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
    readonly TicketDetailMapper mapper;
    readonly Lazy<ITicketEditor> editor;

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
    public ActionResult Edit(EditTicketTitleAndDescriptionSpecification spec)
    {
      var request = MapRequest(spec);
      var response = editor.Value.Edit(request);

      if(response.IdentityIsInvalid)
        return HttpNotFound();

      TempData.Clear();

      if(response.IsSuccess)
      {
        TempData.Add(SuccessfulEditKey, true);
        return RedirectToAction(nameof(Index), new { id = spec.Identity?.Value });
      }

      var responseModel = MapEditResponse(response);
      TempData.Add(EditTicketResponseKey, responseModel);
      TempData.Add(EditTicketSpecKey, spec);

      return RedirectToAction(nameof(Edit), new { id = spec.Identity?.Value });
    }

    TicketDetailModel GetViewTicketModel(Ticket ticket)
    {
      var model = ModelFactory.GetModel<TicketDetailModel>();
      model.Ticket = mapper.Map(ticket);
      return model;
    }

    void PopulateCreateCommentModelProperties(TicketDetailModel model)
    {
      if(model == null)
        throw new ArgumentNullException(nameof(model));

      model.AddCommentSpecification = GetTempData<AddCommentSpecification>(CommentController.CommentSpecKey);
      model.AddCommentResponse = GetTempData<AddCommentResponse>(CommentController.CommentResponseKey);
    }

    EditTicketTitleAndDescriptionModel GetEditTicketModel(Ticket ticket)
    {
      var model = ModelFactory.GetModel<EditTicketTitleAndDescriptionModel>();
      model.Ticket = mapper.Map(ticket);
      model.Response = GetTempData<Models.EditTicketTitleAndDescriptionResponse>(EditTicketResponseKey);
      model.Specification = GetTempData<EditTicketTitleAndDescriptionSpecification>(EditTicketSpecKey);
      return model;
    }

    EditTicketTitleAndDescriptionRequest MapRequest(EditTicketTitleAndDescriptionSpecification spec)
    {
      if(ReferenceEquals(spec, null))
        return null;

      return new EditTicketTitleAndDescriptionRequest
      {
        Identity = spec.Identity,
        Title = spec.Title,
        Description = spec.Description,
      };
    }

    Models.EditTicketTitleAndDescriptionResponse MapEditResponse(Domain.Tickets.EditTicketTitleAndDescriptionResponse response)
    {
      if(ReferenceEquals(response, null))
        return null;

      return new Models.EditTicketTitleAndDescriptionResponse
      {
        Success = response.IsSuccess,
        TitleIsInvalid = response.TitleIsInvalid,
        DescriptionIsInvalid = response.DescriptionIsInvalid,
      };
    }

    public TicketController(ITicketDetailService ticketDetailService,
                            TicketDetailMapper mapper,
                            Lazy<ITicketEditor> editor,
                            Services.SharedModel.StandardPageModelFactory modelFactory)
      : base(modelFactory)
    {
      if(editor == null)
        throw new ArgumentNullException(nameof(editor));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(ticketDetailService == null)
        throw new ArgumentNullException(nameof(ticketDetailService));
      
      this.ticketDetailService = ticketDetailService;
      this.mapper = mapper;
      this.editor = editor;
    }
  }
}
