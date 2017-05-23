using System;
using Agiil.Tests.Auth;
using Agiil.Web.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class PasswordChangeSteps
  {
    readonly IChangePasswordController controller;

    [When("the user submits a request to change their password with the following details:")]
    public void WhenTheUserTriesToChangeTheirPassword(Table changeSpec)
    {
      var spec = changeSpec.CreateInstance<ChangePasswordSpecification>();
      controller.ChangePassword(spec);
    }

    public PasswordChangeSteps(IChangePasswordController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      this.controller = controller;
    }
  }
}
