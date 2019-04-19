using System;
using Agiil.BDD.Models.Tickets;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Labels;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class CreateANewTicket : Performable
  {
    readonly TicketCreationDetails details;

    protected override string GetReport(INamed actor) => $"{actor.Name} creates a new ticket: {details.ToString()}";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage<CreateNewTicket>());

      if(!String.IsNullOrEmpty(details.Title))
        actor.Perform(Enter.TheText(details.Title).Into(CreateNewTicket.TicketTitle));

      if(!String.IsNullOrEmpty(details.Description))
        actor.Perform(Enter.TheText(details.Description).Into(CreateNewTicket.TicketDescription));

      if(!String.IsNullOrEmpty(details.Labels))
        actor.Perform(EnterTheLabels.Named(details.Labels));

      if(!String.IsNullOrEmpty(details.Sprint))
        actor.Perform(Select.Item(details.Sprint).From(CreateNewTicket.TicketSprint));

      if(!String.IsNullOrEmpty(details.Type))
        actor.Perform(Select.Item(details.Type).From(CreateNewTicket.TicketType));

      actor.Perform(Navigate.ToAnotherPageByClicking(CreateNewTicket.CreateButton));
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
