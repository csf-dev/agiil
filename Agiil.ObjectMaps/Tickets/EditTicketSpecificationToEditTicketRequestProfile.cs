using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class EditTicketSpecificationToEditTicketRequestProfile : Profile
  {
    public EditTicketSpecificationToEditTicketRequestProfile()
    {
      CreateMap<EditTicketSpecification,EditTicketRequest>()
        .AfterMap((spec, request) => {
          request.RelationshipsToRemove = request.RelationshipsToRemove
            .Where(x => x?.TicketRelationshipId != null)
            .ToList();
        });
    }
  }
}
