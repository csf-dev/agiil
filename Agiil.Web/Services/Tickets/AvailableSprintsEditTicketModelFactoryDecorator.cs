using System;
using System.Linq;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Sprints;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Services.Tickets
{
  public class AvailableSprintsEditTicketModelFactoryDecorator : IGetsEditTicketModel
  {
    readonly IGetsEditTicketModel wrapped;
    readonly ISprintLister sprintLister;
    readonly IMapper mapper;

    public EditTicketModel GetEditTicketModel(Ticket ticket)
    {
      var model = wrapped.GetEditTicketModel(ticket);

      model.AvailableSprints = sprintLister.GetSprints()
        .Select(x => mapper.Map<SprintSummaryDto>(x))
        .ToList();

      return model;
    }

    public AvailableSprintsEditTicketModelFactoryDecorator(IGetsEditTicketModel wrapped,
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
