using System;
using Agiil.Domain.Activity;
using Agiil.Web.Models.Activity;
using AutoMapper;

namespace Agiil.ObjectMaps.Activity
{
  public class AddTicketWorkLogModelToAddWorkLogRequestProfile : Profile
  {
    public AddTicketWorkLogModelToAddWorkLogRequestProfile()
    {
      CreateMap<AddTicketWorkLogModel,AddWorkLogRequest>()
        .ForMember(x => x.User, o => o.Ignore());
    }
  }
}
