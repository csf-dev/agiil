using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Models.Tickets
{
  public class TicketDetailDto : TicketInfoDtoBase
  {
    public string Description { get; set; }
    public string HtmlDescription { get; set; }

    public SprintSummaryDto Sprint { get; set; }

    public TicketTypeDto Type { get; set; }

    public IEnumerable<CommentDto> Comments { get; set; }

    public TicketDetailDto()
    {
      Comments = Enumerable.Empty<CommentDto>().ToArray();
    }
  }
}
