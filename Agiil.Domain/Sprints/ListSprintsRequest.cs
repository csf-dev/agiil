using System;
namespace Agiil.Domain.Sprints
{
  public class ListSprintsRequest
  {
    public bool ShowOpenSprints { get; set; }

    public bool ShowClosedSprints { get; set; }

    public ListSprintsRequest()
    {
      ShowOpenSprints = true;
      ShowClosedSprints = false;
    }
  }
}
