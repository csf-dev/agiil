using System;
using Agiil.Domain.Tickets;

namespace Agiil.Web.Models.Tickets
{
  public abstract class TicketInfoDtoBase
  {
    readonly IGetsTicketUris uriProvider;

    public long Id { get; set; }

    public string Reference => TicketReference?.ToString(false);

    public TicketReference TicketReference { get; set; }

    public string EditUrl => uriProvider.GetEditTicketUri(TicketReference)?.ToString();

    public string ViewUrl => uriProvider.GetViewTicketUri(TicketReference)?.ToString();

    public string Title { get; set; }

    public string Creator { get; set; }

    public DateTime Created { get; set; }

    public bool Closed { get; set; }

    public string CreationTimestamp => Created.ToString("u");

    public string TypeName { get; set; }

    public int? StoryPoints { get; set; }

    public bool HasStoryPoints
      => StoryPoints.HasValue && StoryPoints.Value > 0;

    public TicketInfoDtoBase(IGetsTicketUris uriProvider)
    {
      if(uriProvider == null)
        throw new ArgumentNullException(nameof(uriProvider));
      this.uriProvider = uriProvider;
    }
  }
}
