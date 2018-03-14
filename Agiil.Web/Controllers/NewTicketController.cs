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
  public class NewTicketController : Controller
  {
    public static readonly string NewModelKey = "NewModel";

    readonly ITicketCreator ticketCreator;
    readonly Lazy<ISprintLister> sprintLister;
    readonly Lazy<ITicketTypeProvider> ticketTypeProvider;
    readonly IMapper mapper;

    [HttpGet]
    public ActionResult Index()
    {
      var model = TempData.TryGet<NewTicketModel>(NewModelKey)?? GetModel();
      return View(model);
    }

    [HttpPost]
    public ActionResult Create(NewTicketSpecification spec)
    {
      var model = GetModel(spec);
      var request = mapper.Map<CreateTicketRequest>(spec);
      var response = ticketCreator.Create(request);
      model.Response = mapper.Map<NewTicketResponse>(response);
      TempData.Add(NewModelKey, model);
      return RedirectToAction(nameof(NewTicketController.Index));
    }

    NewTicketModel GetModel(NewTicketSpecification spec = null)
    {
      var model = new NewTicketModel();
      model.Specification = spec;
      model.AvailableSprints = sprintLister
        .Value
        .GetSprints()
        .Select(x => mapper.Map<SprintSummaryDto>(x))
        .ToList();
      model.AvailableTicketTypes = ticketTypeProvider
        .Value
        .GetTicketTypes()
        .Select(x => mapper.Map<TicketTypeDto>(x))
        .ToList();
      return model;
    }

    public NewTicketController(ITicketCreator ticketCreator,
                               Lazy<ISprintLister> sprintLister,
                               Lazy<ITicketTypeProvider> ticketTypeProvider,
                              IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      this.mapper = mapper;
      if(ticketTypeProvider == null)
        throw new ArgumentNullException(nameof(ticketTypeProvider));
      if(sprintLister == null)
        throw new ArgumentNullException(nameof(sprintLister));
      if(ticketCreator == null)
        throw new ArgumentNullException(nameof(ticketCreator));

      this.ticketCreator = ticketCreator;
      this.sprintLister = sprintLister;
      this.ticketTypeProvider = ticketTypeProvider;
    }
  }
}
