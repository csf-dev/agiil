using System;
using Agiil.Auth;
using Agiil.BDD.Controllers.Auth;
using Agiil.Domain.Auth;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class LoginSteps
  {
    readonly ILoginController loginController;
    readonly IIdentityReader identityReader;

    [When("the user attempts to log in with a username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void WhenTheUserAttemptsToLogin(string username, string password)
    {
      loginController.Login(username, password);
    }

    [Then("the user is logged in successfully")]
    public void ThenTheUserIsLoggedInSuccessfully()
    {
      var currentUser = identityReader.GetCurrentUserInfo();
      Assert.NotNull(currentUser);
    }

    [Then("the user is not logged in successfully")]
    public void ThenTheUserIsNotLoggedInSuccessfully()
    {
      var currentUser = identityReader.GetCurrentUserInfo();
      Assert.IsNull(currentUser);
    }

    public LoginSteps(ILoginController loginController, IIdentityReader identityReader)
    {
      if(identityReader == null)
        throw new ArgumentNullException(nameof(identityReader));
      if(loginController == null)
        throw new ArgumentNullException(nameof(loginController));
      
      this.loginController = loginController;
      this.identityReader = identityReader;
    }
  }
}
