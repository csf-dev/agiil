using System;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class NewTicketController : ControllerBase
  {
    public static readonly string NewModelKey = "NewModel";

    readonly ITicketCreator ticketCreator;

    [HttpGet]
    public ActionResult Index()
    {
      var model = GetTempData<NewTicketModel>(NewModelKey)?? GetModel();
      return View(model);
    }

    [HttpPost]
    public ActionResult Create(NewTicketSpecification spec)
    {
      var model = GetModel(spec);
      var request = new CreateTicketRequest
      {
        Title = model.Specification?.Title,
        Description = model.Specification?.Description,
      };

      var response = ticketCreator.Create(request);
      model.Response = new NewTicketResponse
      {
        TitleIsInvalid = response.TitleIsInvalid,
        DescriptionIsInvalid = response.DescriptionIsInvalid,
        TicketIdentity = response.Ticket?.GetIdentity()?.Value,
      };

      TempData.Add(NewModelKey, model);
      return RedirectToAction(nameof(NewTicketController.Index));
    }

    NewTicketModel GetModel(NewTicketSpecification spec = null)
    {
      var model = ModelFactory.GetModel<NewTicketModel>();
      model.Specification = spec;
      return model;
    }

    public NewTicketController(ITicketCreator ticketCreator, Services.SharedModel.StandardPageModelFactory modelFactory)
      : base(modelFactory)
    {
      if(ticketCreator == null)
        throw new ArgumentNullException(nameof(ticketCreator));

      this.ticketCreator = ticketCreator;
    }
  }
}
