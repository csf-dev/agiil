using System;
using Agiil.Domain.Labels;
using Agiil.Web.Models.Labels;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class LabelToLabelDtoProfile : Profile
  {
    public LabelToLabelDtoProfile()
    {
      CreateMap<Label,LabelDto>();
    }
  }
}
