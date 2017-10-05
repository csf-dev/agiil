using System;
using System.Collections.Generic;

namespace Agiil.BDD.Models.Tickets
{
  public class TicketCreationDetails
  {
    public string Title { get; set; }

    public string Description { get; set; }

    public string Sprint { get; set; }

    public string Type { get; set; }

    public override string ToString()
    {
      var components = new List<string>();

      components.Add($"Title: {Title?? "<null>"}");

      if(!String.IsNullOrEmpty(Description))
        components.Add($"Description: {Description}");

      if(!String.IsNullOrEmpty(Sprint))
        components.Add($"Sprint: {Sprint}");

      if(!String.IsNullOrEmpty(Type))
        components.Add($"Type: {Type}");

      return $"[{String.Join(", ", components)}]";
    }
  }
}
