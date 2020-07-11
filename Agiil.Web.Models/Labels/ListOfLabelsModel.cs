using System;
using System.Collections.Generic;

namespace Agiil.Web.Models.Labels
{
  public class ListOfLabelsModel
  {
    public IReadOnlyList<ListedLabelDto> Labels { get; set; }
  }
}
