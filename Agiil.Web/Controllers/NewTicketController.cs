using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;

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
    public ActionResult Create(NewTicketModel model)
    {
      model = model?? new NewTicketModel();
      var request = new CreateTicketRequest
      {
        Title = model.Title,
        Description = model.Description,
      };

      var response = ticketCreator.Create(request);

      // TODO: Write this implementation
      throw new NotImplementedException();
    }

    void MapValidationToModel(CreateTicketResponse response, ref NewTicketModel model)
    {
    }
  }
}
