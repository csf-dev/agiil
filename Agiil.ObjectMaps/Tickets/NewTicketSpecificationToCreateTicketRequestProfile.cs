using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class NewTicketSpecificationToCreateTicketRequestProfile : Profile
  {
    public NewTicketSpecificationToCreateTicketRequestProfile()
    {
      CreateMap<NewTicketSpecification,CreateTicketRequest>();
    }
  }
}
