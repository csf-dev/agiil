using System;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class DeletingACommentSteps
  {
    readonly IStage stage;

    [When(@"(?:he|she|they) deletes? the first editable comment")]
    public void WhenTheyDeleteTheMostRecentComment()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo<DeleteTheFirstDeletableComment>();
    }

    [When(@"(?:he|she|they) deletes? the first editable comment without confirming")]
    public void WhenTheyDeleteTheMostRecentCommentWithoutConfirming()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo<DeleteTheFirstDeletableCommentWithoutConfirming>();
    }

    public DeletingACommentSteps(IStage stage)
    {
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.stage = stage;
    }
  }
}
