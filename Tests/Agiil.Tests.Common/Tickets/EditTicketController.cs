using System;
using System.Linq;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Tests.Tickets
{
  public class EditTicketController : IEditTicketController
  {
    readonly Web.Controllers.TicketController webController;
    readonly IRepository<Ticket> ticketRepo;
    readonly IRepository<Sprint> sprintRepo;
    readonly IMapper mapper;
    readonly ITicketReferenceQuery query;

    public void Edit(EditTicketTitleAndDescriptionSpecification request)
    {
      if(request == null)
        return;

      var ticket = ticketRepo.Get(request.Identity);
      if(ticket == null)
        return;

      var editRequest = mapper.Map<EditTicketSpecification>(ticket);
      mapper.Map(request, editRequest);

      webController.Edit(editRequest);
    }

    public void AddToSprint(string ticketReference, string sprintName)
    {
      var ticket = query.GetTicketByReference(ticketReference);
      if(ticket == null)
        return;
      
      var sprint = sprintRepo.Query().SingleOrDefault(x => x.Name == sprintName);
      if(sprint == null)
        return;

      var editRequest = mapper.Map<EditTicketSpecification>(ticket);
      editRequest.SprintIdentity = sprint.GetIdentity();

      webController.Edit(editRequest);

    }

    public EditTicketController(Web.Controllers.TicketController webController,
                                IRepository<Ticket> ticketRepo,
                                IMapper mapper,
                                ITicketReferenceQuery query,
                                IRepository<Sprint> sprintRepo)
    {
      if(sprintRepo == null)
        throw new ArgumentNullException(nameof(sprintRepo));
      if(query == null)
        throw new ArgumentNullException(nameof(query));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));
      if(webController == null)
        throw new ArgumentNullException(nameof(webController));

      this.webController = webController;
      this.mapper = mapper;
      this.ticketRepo = ticketRepo;
      this.query = query;
      this.sprintRepo = sprintRepo;
    }
  }
}
