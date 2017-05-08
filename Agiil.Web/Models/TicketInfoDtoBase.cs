using System;
namespace Agiil.Web.Models
{
  public abstract class TicketInfoDtoBase
  {
    public long Id { get; set; }

    public string Title { get; set; }

    public string Creator { get; set; }

    public DateTime Created { get; set; }

    public string CreationTimestamp => Created.ToString("u");
  }
}
