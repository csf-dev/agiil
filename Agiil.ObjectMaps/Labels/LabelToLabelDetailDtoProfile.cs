using System;
using Agiil.Domain.Labels;
using Agiil.Web.Models.Labels;
using AutoMapper;

namespace Agiil.ObjectMaps.Labels
{
  public class LabelToLabelDetailDtoProfile : Profile
  {
    public LabelToLabelDetailDtoProfile()
    {
      CreateMap<Label,LabelDetailDto>();
    }
  }
}
