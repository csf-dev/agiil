using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Services.Tickets
{
  public class AvailableRelationshipsNewTicketModelFactoryDecorator : IGetsNewTicketModel
  {
    readonly IGetsNewTicketModel wrapped;
    readonly IGetsAvailableRelationships relationshipProvider;
    readonly IMapper mapper;

    public NewTicketModel GetNewTicketModel(NewTicketSpecification spec)
    {
      var model = wrapped.GetNewTicketModel(spec);
      AddAvailableRelationships(model);
      return model;
    }

    void AddAvailableRelationships(IHasAvailableRelationships model)
    {
      var relationships = relationshipProvider.GetAvailableRelationships();
      model.AvailableRelationships = mapper.Map<IList<AvailableRelationshipDto>>(relationships);
    }

    public AvailableRelationshipsNewTicketModelFactoryDecorator(IGetsNewTicketModel wrapped,
                                                                 IGetsAvailableRelationships relationshipProvider,
                                                                 IMapper mapper)
    {
      if(wrapped == null)
        throw new ArgumentNullException(nameof(wrapped));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(relationshipProvider == null)
        throw new ArgumentNullException(nameof(relationshipProvider));
      this.wrapped = wrapped;
      this.relationshipProvider = relationshipProvider;
      this.mapper = mapper;
    }
  }
}
