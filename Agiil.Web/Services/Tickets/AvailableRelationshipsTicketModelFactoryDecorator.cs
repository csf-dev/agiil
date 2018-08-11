using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Services.Tickets
{
  public class AvailableRelationshipsTicketModelFactoryDecorator : IGetsEditTicketModel
  {
    readonly IGetsEditTicketModel wrapped;
    readonly IGetsAvailableRelationships relationshipProvider;
    readonly IMapper mapper;

    public EditTicketModel GetEditTicketModel(Ticket ticket)
    {
      var model = wrapped.GetEditTicketModel(ticket);
      AddAvailableRelationships(model);
      return model;
    }

    void AddAvailableRelationships(IHasAvailableRelationships model)
    {
      var relationships = relationshipProvider.GetAvailableRelationships();
      model.AvailableRelationships = mapper.Map<IList<AvailableRelationshipDto>>(relationships);
    }

    public AvailableRelationshipsTicketModelFactoryDecorator(IGetsEditTicketModel wrapped,
                                                                 IGetsAvailableRelationships relationshipProvider,
                                                                 IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(relationshipProvider == null)
        throw new ArgumentNullException(nameof(relationshipProvider));
      if(wrapped == null)
        throw new ArgumentNullException(nameof(wrapped));
      this.wrapped = wrapped;
      this.relationshipProvider = relationshipProvider;
      this.mapper = mapper;
    }
  }
}
