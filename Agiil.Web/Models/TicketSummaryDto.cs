using System;
namespace Agiil.Web.Models
{
  public class TicketSummaryDto : TicketInfoDtoBase
  {
    public string ShortTimestamp => Created.ToString("D");
  }
}
