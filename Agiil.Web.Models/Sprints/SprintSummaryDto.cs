using System;
using Agiil.Domain.Sprints;
using CSF.Entities;

namespace Agiil.Web.Models.Sprints
{
  public class SprintSummaryDto
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string GetShortStartDate()
    {
      if(!StartDate.HasValue)
        return null;

      return StartDate.Value.ToString("D");
    }

    public string GetShortEndDate()
    {
      if(!EndDate.HasValue)
        return null;

      return EndDate.Value.ToString("D");
    }

    public string GetLongStartDate()
    {
      if(!StartDate.HasValue)
        return null;

      return StartDate.Value.ToString("u");
    }

    public string GetLongEndDate()
    {
      if(!EndDate.HasValue)
        return null;

      return EndDate.Value.ToString("u");
    }

    public string GetHtmlClasses()
    {
      return null;
    }
  }
}
