using System;
using System.Collections.Generic;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Models.Tickets
{
  public class EditTicketModel : PageModel, IHasAvailableSprints, IHasAvailableTicketTypes, IHasAvailableRelationships
  {
    public TicketDetailDto  Ticket { get; set; }

    public IList<SprintSummaryDto> AvailableSprints { get; set; }

    public IList<TicketTypeDto> AvailableTicketTypes { get; set; }

    public IList<AvailableRelationshipDto> AvailableRelationships { get; set; }

    public EditTicketSpecification Specification { get; set; }

    public EditTicketResponse Response { get; set; }

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

    public EditTicketModel()
    {
      Specification = new EditTicketSpecification();
      EmptyRelationshipSlots = 3;
    }
  }
}
