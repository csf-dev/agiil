using System;
using Agiil.Tests.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Tests.ObjectMaps.Tickets
{
  public class EditTicketTitleAndDescriptionSpecificationToEditTicketSpecificationProfile : Profile
  {
    public EditTicketTitleAndDescriptionSpecificationToEditTicketSpecificationProfile()
    {
      CreateMap<EditTicketTitleAndDescriptionSpecification,EditTicketSpecification>();
    }
  }
}
