using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Web.Models.Tickets
{
  public class TicketDetailDto : TicketInfoDtoBase
  {
    public string Description { get; set; }

    public IEnumerable<CommentDto> Comments { get; set; }

    public TicketDetailDto()
    {
      Comments = Enumerable.Empty<CommentDto>().ToArray();
    }
  }
}
