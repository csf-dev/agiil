using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;
using CSF.Entities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketEditingSteps
  {
    readonly IEditTicketController ticketEditor;

    [When("the user requests to edit a ticket title and description with the following specification:")]
    public void TheUserAttemptsToCreateATicket(Table ticketProperties)
    {
      var spec = ticketProperties.CreateInstance<EditTicketTitleAndDescriptionSpecification>();
      spec.Identity = Identity.Parse<Ticket>(ticketProperties.Rows[0].GetString("Id"));
      ticketEditor.Edit(spec);
    }

    public TicketEditingSteps(IEditTicketController ticketEditor)
    {
      if(ticketEditor == null)
        throw new ArgumentNullException(nameof(ticketEditor));

      this.ticketEditor = ticketEditor;
    }
  }
}
