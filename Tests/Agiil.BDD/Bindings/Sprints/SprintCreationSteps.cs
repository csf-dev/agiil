using System;
using Agiil.Tests.Autofixture;
using Agiil.Tests.Sprints;
using Agiil.Web.Models.Sprints;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintCreationSteps
  {
    readonly Lazy<IBulkSprintCreator> bulkSprintCreator;
    readonly Lazy<ISprintCreationController> controller;
    readonly IFixture autoFixture;

    [When("the user creates a sprint with the following details:")]
    public void WhenTheUserCreatesASprint(Table spec)
    {
      var request = spec.CreateInstance<NewSprintSpecification>();
      controller.Value.Create(request);
    }

    [Given("the following sprints exist:")]
    public void GivenASetOfSprintsExist(Table specs)
    {
      new BulkSprintCreationSpecificationCustomization().Customize(autoFixture);
      var request = specs.CreateSet(() => autoFixture.Create<BulkSprintCreationSpecification>());
      bulkSprintCreator.Value.Create(request);
    }

    public SprintCreationSteps(Lazy<ISprintCreationController> controller,
                               Lazy<IBulkSprintCreator> bulkSprintCreator,
                               IFixture autoFixture)
    {
      if(autoFixture == null)
        throw new ArgumentNullException(nameof(autoFixture));
      if(bulkSprintCreator == null)
        throw new ArgumentNullException(nameof(bulkSprintCreator));
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));

      this.autoFixture = autoFixture;
      this.controller = controller;
      this.bulkSprintCreator = bulkSprintCreator;
    }
  }
}
