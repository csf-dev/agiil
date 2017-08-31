using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Web.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketCreationSteps
  {
    readonly IScreenplayScenario screenplay;

    [When("Youssef creates the following ticket using the create ticket page")]
    public void WhenYoussefCreatesATicket(Table detailsTable)
    {
      var details = detailsTable.CreateInstance<TicketCreationDetails>();

      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(CreateANewTicket.WithTheDetails(details));
    }

    [Then("Youssef should see a ticket created success message")]
    public void ThenYoussefShouldSeeATicketCreatedSuccessMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.Of(CreateNewTicket.CreationSuccessMessage))
                   .Should()
                   .StartWith("The ticket was created successfully", because: "The ticket creation was a success");
    }

    [Then("Youssef should see a ticket creation failure message")]
    public void ThenYoussefShouldSeeATicketCreationFailureMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.Of(CreateNewTicket.CreationFailureMessage))
                   .Should()
                   .StartWith("The ticket was not created", because: "The ticket creation failed");
    }

    public TicketCreationSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
