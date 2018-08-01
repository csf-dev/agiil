using System;
using Agiil.Web.Models.Labels;

namespace Agiil.Web.Services.Labels
{
  public interface IGetsLabelDetail
  {
    LabelDetailDto GetLabelDetail(string labelName);
  }
}
