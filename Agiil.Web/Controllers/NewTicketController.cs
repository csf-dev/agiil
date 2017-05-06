using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
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
      var model = GetTempData<NewTicketModel>(NewModelKey)?? new NewTicketModel();
      return View(model);
    }

    [HttpPost]
    public ActionResult Create(NewTicketSpecification spec)
    {
      var model = new NewTicketModel
      {
        Specification = spec,
      };
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

    public NewTicketController(ITicketCreator ticketCreator)
    {
      if(ticketCreator == null)
        throw new ArgumentNullException(nameof(ticketCreator));

      this.ticketCreator = ticketCreator;
    }
  }
}
