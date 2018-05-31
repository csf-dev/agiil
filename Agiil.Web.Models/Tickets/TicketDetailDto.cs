using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Web.Models.Labels;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Models.Tickets
{
  public class TicketDetailDto : TicketInfoDtoBase
  {
    public string Description { get; set; }
    public string HtmlDescription { get; set; }

    public string CommaSeparatedLabelNames { get; set; }

    public IEnumerable<LabelDto> Labels { get; set; }

    public bool HasLabels
      => Labels != null && Labels.Any();

    public SprintSummaryDto Sprint { get; set; }

    public TicketTypeDto Type { get; set; }

    public IEnumerable<CommentDto> Comments { get; set; }

    public TicketDetailDto()
    {
      Comments = Enumerable.Empty<CommentDto>().ToArray();
      Labels = Enumerable.Empty<LabelDto>().ToArray();
    }
  }
}
