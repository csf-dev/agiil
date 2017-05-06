using System;
using Agiil.Auth;
using Agiil.Domain.Auth;
using CSF.Data.Entities;
using CSF.Security.Authentication;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Auth
{
  public class TestingUserCreator : UserCreator
  {
    readonly IFixture autoFixture;

    protected override User CreateUser()
    {
      var user = autoFixture.Create<User>();
      user.GenerateIdentity();
      return user;
    }

    public TestingUserCreator(IRepository<User> repo,
                              Func<User> userFactory,
                              ICredentialsCreator credentialsCreator,
                              ICredentialsSerializer credentialsSerializer,
                              IFixture autoFixture)
      : base(repo, userFactory, credentialsCreator, credentialsSerializer)
    {
      if(autoFixture == null)
        throw new ArgumentNullException(nameof(autoFixture));

      this.autoFixture = autoFixture;
    }
  }
}
