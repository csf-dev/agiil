using System;
using Agiil.BDD.Controllers.Auth;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class UserAccountSteps
  {
    readonly IUserAccountController userAccountModel;

    [Given(@"there is not a user account named '([A-Za-z0-9_-]+)'")]
    public void GivenThereIsNotAUser(string username)
    {
      userAccountModel.RemoveUser(username);
    }

    [Given(@"there is a user account named '([A-Za-z0-9_-]+)' with the password '([^']+)'")]
    public void GivenThereIsAUserWithAPassword(string username, string password)
    {
      userAccountModel.AddUser(username, password);
    }

    public UserAccountSteps(IUserAccountController userAccountModel)
    {
      if(userAccountModel == null)
        throw new ArgumentNullException(nameof(userAccountModel));

      this.userAccountModel = userAccountModel;
    }
  }
}
