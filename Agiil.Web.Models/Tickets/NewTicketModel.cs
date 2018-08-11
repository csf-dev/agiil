using System;
using System.Collections.Generic;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Models.Tickets
{
  public class NewTicketModel : PageModel, IHasAvailableSprints, IHasAvailableTicketTypes, IHasAvailableRelationships
  {
    public NewTicketSpecification Specification { get; set; }

    public NewTicketResponse Response { get; set; }

    public IList<SprintSummaryDto> AvailableSprints { get; set; }

    public IList<TicketTypeDto> AvailableTicketTypes { get; set; }

    public IList<AvailableRelationshipDto> AvailableRelationships { get; set; }

    public int EmptyRelationshipSlots { get; set; }

    public IEnumerable<AddRelationshipModel> AddRelationshipModels {
      get {
        var alreadyToAdd = Specification?.RelationshipsToAdd ?? new List<AddRelationshipModel>();
        var output = new List<AddRelationshipModel>(alreadyToAdd);

        while(output.Count < EmptyRelationshipSlots)
          output.Add(null);

        return output;
      }
    }

    public NewTicketModel()
    {
      Specification = new NewTicketSpecification();
      EmptyRelationshipSlots = 3;
    }
  }
}
