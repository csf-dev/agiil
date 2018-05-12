using System;
using Agiil.Domain.Labels;
using Agiil.Web.Models.Labels;
using AutoMapper;

namespace Agiil.ObjectMaps.Labels
{
  public class ListedLabelToListedLabelDtoProfile : Profile
  {
    public ListedLabelToListedLabelDtoProfile()
    {
      CreateMap<ListedLabel,ListedLabelDto>();
    }
  }
}
