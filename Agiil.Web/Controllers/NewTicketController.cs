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
  public class NewTicketController : Controller
  {
    public static readonly string NewModelKey = "NewModel";

    readonly IHandlesCreateTicketRequest ticketCreator;
    readonly Lazy<IGetsNewTicketModel> ticketModelFactory;
    readonly IMapper mapper;

    [HttpGet]
    public ActionResult Index()
    {
      var model = TempData.TryGet<NewTicketModel>(NewModelKey)?? ticketModelFactory.Value.GetNewTicketModel(null);
      return View(model);
    }

    [HttpPost]
    public ActionResult Create(NewTicketSpecification spec)
    {
      var model = ticketModelFactory.Value.GetNewTicketModel(spec);
      var request = mapper.Map<CreateTicketRequest>(spec);
      var response = ticketCreator.Create(request);
      model.Response = mapper.Map<NewTicketResponse>(response);
      TempData.Add(NewModelKey, model);
      return RedirectToAction(nameof(NewTicketController.Index));
    }

    public NewTicketController(IHandlesCreateTicketRequest ticketCreator,
                               Lazy<IGetsNewTicketModel> ticketModelFactory,
                              IMapper mapper)
    {
      if(ticketModelFactory == null)
        throw new ArgumentNullException(nameof(ticketModelFactory));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(ticketCreator == null)
        throw new ArgumentNullException(nameof(ticketCreator));

      this.mapper = mapper;
      this.ticketCreator = ticketCreator;
      this.ticketModelFactory = ticketModelFactory;
    }
  }
}
