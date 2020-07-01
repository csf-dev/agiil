using System;
using System.Linq;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Sprints;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Services.Tickets
{
  public class AvailableSprintsTicketModelFactoryDecorator : IGetsEditTicketModel
  {
    readonly IGetsEditTicketModel wrapped;
    readonly ISprintLister sprintLister;
    readonly IMapper mapper;

    public EditTicketModel GetEditTicketModel(Ticket ticket)
    {
      var model = wrapped.GetEditTicketModel(ticket);
      AddAvailableSprints(model);
      return model;
    }

    void AddAvailableSprints(IHasAvailableSprints model)
    {
      model.AvailableSprints = sprintLister.GetSprints(new ListSprintsRequest())
        .Select(mapper.Map<SprintSummaryDto>)
        .ToList();
    }

    public AvailableSprintsTicketModelFactoryDecorator(IGetsEditTicketModel wrapped,
                                                       ISprintLister sprintLister,
                                                       IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(sprintLister == null)
        throw new ArgumentNullException(nameof(sprintLister));
      if(wrapped == null)
        throw new ArgumentNullException(nameof(wrapped));
      
      this.wrapped = wrapped;
      this.sprintLister = sprintLister;
      this.mapper = mapper;
    }
  }
}
