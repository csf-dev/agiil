using System;
namespace Agiil.Web.Models.Tickets
{
  public abstract class TicketInfoDtoBase
  {
    public long Id { get; set; }

    public string Reference { get; set; }

    public string Title { get; set; }

    public string Creator { get; set; }

    public DateTime Created { get; set; }

    public bool Closed { get; set; }

    public string CreationTimestamp => Created.ToString("u");

    public string TypeName { get; set; }

    public int? StoryPoints { get; set; }

    public bool HasStoryPoints
      => StoryPoints.HasValue && StoryPoints.Value > 0;
  }
}
