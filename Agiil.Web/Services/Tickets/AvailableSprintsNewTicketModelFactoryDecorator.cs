using System;
using System.Linq;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Sprints;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Services.Tickets
{
  public class AvailableSprintsNewTicketModelFactoryDecorator : IGetsNewTicketModel
  {
    readonly IGetsNewTicketModel wrapped;
    readonly ISprintLister sprintLister;
    readonly IMapper mapper;

    public NewTicketModel GetNewTicketModel(NewTicketSpecification spec)
    {
      var model = wrapped.GetNewTicketModel(spec);
      AddAvailableSprints(model);
      return model;
    }

    void AddAvailableSprints(IHasAvailableSprints model)
    {
      model.AvailableSprints = sprintLister.GetSprints()
        .Select(mapper.Map<SprintSummaryDto>)
        .ToList();
    }

    public AvailableSprintsNewTicketModelFactoryDecorator(IGetsNewTicketModel wrapped,
                                                       ISprintLister sprintLister,
                                                       IMapper mapper)
    {
      if(wrapped == null)
        throw new ArgumentNullException(nameof(wrapped));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(sprintLister == null)
        throw new ArgumentNullException(nameof(sprintLister));
      
      this.wrapped = wrapped;
      this.sprintLister = sprintLister;
      this.mapper = mapper;
    }
  }
}
