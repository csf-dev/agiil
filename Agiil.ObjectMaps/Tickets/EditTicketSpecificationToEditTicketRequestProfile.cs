using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class EditTicketSpecificationToEditTicketRequestProfile : Profile
  {
    public EditTicketSpecificationToEditTicketRequestProfile()
    {
      CreateMap<EditTicketSpecification,EditTicketRequest>();
    }
  }
}
