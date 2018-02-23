using System;
using Agiil.BDD.Models.Tickets;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketCreationSteps
  {
    readonly ICast cast;

    [When("Youssef creates the following ticket using the create ticket page")]
    public void WhenYoussefCreatesATicket(Table detailsTable)
    {
      var details = detailsTable.CreateInstance<TicketCreationDetails>();

      var youssef = cast.Get<Youssef>();
      When(youssef).AttemptsTo(CreateANewTicket.WithTheDetails(details));
    }

    [Then("Youssef should see a ticket created success message")]
    public void ThenYoussefShouldSeeATicketCreatedSuccessMessage()
    {
      var youssef = cast.Get<Youssef>();
      Then(youssef).ShouldSee(TheText.Of(CreateNewTicket.CreationSuccessMessage))
                   .Should()
                   .StartWith("The ticket was created successfully", because: "The ticket creation was a success");
    }

    [Then("Youssef should see a ticket creation failure message")]
    public void ThenYoussefShouldSeeATicketCreationFailureMessage()
    {
      var youssef = cast.Get<Youssef>();
      Then(youssef).ShouldSee(TheText.Of(CreateNewTicket.CreationFailureMessage))
                   .Should()
                   .StartWith("The ticket was not created", because: "The ticket creation failed");
    }

    public TicketCreationSteps(ICast cast)
    {
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.cast = cast;
    }
  }
}
