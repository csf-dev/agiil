using System;
using Agiil.Tests.Auth;
using CSF.Screenplay.Actors;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class UserAccountSteps
  {
    readonly IUserAccountController userAccountModel;
    readonly ICast cast;
    readonly IFixture autofixture;

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

    [Given(@"there is a user account named '([A-Za-z0-9_-]+)'")]
    public void GivenThereIsAUser(string username)
    {
      var password = autofixture.Create<string>();
      userAccountModel.AddUser(username, password);
    }

    [Given("([A-Za-z0-9_-]+) is a regular user")]
    public void GivenTheyAreARegularUser(string username)
    {
      GivenThereIsAUser(username);
      var actor = cast.Add(username);
    }

    public UserAccountSteps(IUserAccountController userAccountModel,
                            IFixture autofixture,
                            ICast cast)
    {
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));
      if(autofixture == null)
        throw new ArgumentNullException(nameof(autofixture));
      if(userAccountModel == null)
        throw new ArgumentNullException(nameof(userAccountModel));

      this.userAccountModel = userAccountModel;
      this.autofixture = autofixture;
      this.cast = cast;
    }
  }
}
