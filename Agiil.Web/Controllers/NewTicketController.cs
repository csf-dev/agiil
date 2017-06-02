using System;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Sprints;
using Agiil.Web.Models.Tickets;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class NewTicketController : ControllerBase
  {
    public static readonly string NewModelKey = "NewModel";

    readonly ITicketCreator ticketCreator;
    readonly Lazy<ISprintLister> sprintLister;

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
      var request = Mapper.Map<CreateTicketRequest>(spec);
      var response = ticketCreator.Create(request);
      model.Response = Mapper.Map<NewTicketResponse>(response);
      TempData.Add(NewModelKey, model);
      return RedirectToAction(nameof(NewTicketController.Index));
    }

    NewTicketModel GetModel(NewTicketSpecification spec = null)
    {
      var model = ModelFactory.GetModel<NewTicketModel>();
      model.Specification = spec;
      model.AvailableSprints = sprintLister
        .Value
        .GetSprints()
        .Select(x => Mapper.Map<SprintSummaryDto>(x))
        .ToList();
      return model;
    }

    public NewTicketController(ITicketCreator ticketCreator,
                               Lazy<ISprintLister> sprintLister,
                               ControllerBaseDependencies baseDeps)
      : base(baseDeps)
    {
      if(sprintLister == null)
        throw new ArgumentNullException(nameof(sprintLister));
      if(ticketCreator == null)
        throw new ArgumentNullException(nameof(ticketCreator));

      this.ticketCreator = ticketCreator;
      this.sprintLister = sprintLister;
    }
  }
}
