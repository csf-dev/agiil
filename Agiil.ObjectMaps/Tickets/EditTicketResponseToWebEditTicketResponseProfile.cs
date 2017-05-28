using System;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class EditTicketResponseToWebEditTicketResponseProfile : Profile
  {
    public EditTicketResponseToWebEditTicketResponseProfile()
    {
      CreateMap<Domain.Tickets.EditTicketResponse, Web.Models.Tickets.EditTicketResponse>();
    }
  }
}
