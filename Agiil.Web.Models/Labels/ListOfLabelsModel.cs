using System;
using System.Collections.Generic;

namespace Agiil.Web.Models.Labels
{
  public class ListOfLabelsModel : PageModel
  {
    public IReadOnlyList<ListedLabelDto> Labels { get; set; }
  }
}
