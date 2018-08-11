using System;
using Agiil.Domain.Labels;
using Agiil.Web.Models.Labels;
using AutoMapper;

namespace Agiil.Web.Services.Labels
{
  public class LabelDetailProvider : IGetsLabelDetail
  {
    readonly IGetsExistingLabel labelReader;
    readonly IMapper mapper;

    public LabelDetailDto GetLabelDetail(string labelName)
    {
      var label = labelReader.GetLabel(labelName);
      if(label == null) return null;

      return mapper.Map<LabelDetailDto>(label);
    }

    public LabelDetailProvider(IGetsExistingLabel labelReader,
                               IMapper mapper)
    {
      if(labelReader == null)
        throw new ArgumentNullException(nameof(labelReader));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      this.labelReader = labelReader;
      this.mapper = mapper;
    }
  }
}
