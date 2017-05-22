﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Web.Models
{
  public class TicketSummaryDto : TicketInfoDtoBase
  {
    public string ShortTimestamp => Created.ToString("D");

    public string GetHtmlClasses()
    {
      var classes = new List<string>();

      if(Closed)
        classes.Add("closed");

      if(!classes.Any())
        return null;

      return String.Join(" ", classes);
    }
  }
}
