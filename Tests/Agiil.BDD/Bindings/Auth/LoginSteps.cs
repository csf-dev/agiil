using System;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Tests.Auth;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class LoginSteps
  {
    const string DUMMY_PASSWORD = "dummypassword";

    readonly ILoginController loginController;
    readonly IIdentityReader identityReader;
    readonly IUserAccountController userAccountController;

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

    [Given("the user is logged in with a user account named '([A-Za-z0-9_-]+)'")]
    public void GivenTheUserIsLoggedInWithAUserAccount(string accountName)
    {
      userAccountController.AddUser(accountName, DUMMY_PASSWORD);
      loginController.Login(accountName, DUMMY_PASSWORD);
    }

    public LoginSteps(ILoginController loginController,
                      IIdentityReader identityReader,
                      IUserAccountController userAccountController)
    {
      if(userAccountController == null)
        throw new ArgumentNullException(nameof(userAccountController));
      if(identityReader == null)
        throw new ArgumentNullException(nameof(identityReader));
      if(loginController == null)
        throw new ArgumentNullException(nameof(loginController));
      
      this.loginController = loginController;
      this.identityReader = identityReader;
      this.userAccountController = userAccountController;
    }
  }
}
