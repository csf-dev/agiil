using System;
using Agiil.BDD.Bindings.Tickets;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public class CreateANewTicket : Performable
  {
    readonly TicketCreationDetails details;

    protected override string GetReport(INamed actor) => $"{actor.Name} creates a new ticket: {details.ToString()}";

    protected override void PerformAs(IPerformer actor)
    {
      throw new NotImplementedException();
    }

    CreateANewTicket(TicketCreationDetails details)
    {
      if(details == null)
        throw new ArgumentNullException(nameof(details));

      this.details = details;
    }

    public static IPerformable WithTheDetails(TicketCreationDetails model)
    {
      return new CreateANewTicket(model);
    }
  }
}
