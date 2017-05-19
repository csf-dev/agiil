using System;
using Agiil.Domain.Auth;
using CSF.Data.Entities;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class UserCreator : UserPasswordSetterBase, IUserCreator
  {
    readonly IRepository<User> repo;
    readonly Func<User> userFactory;

    public virtual void Add(string username, string password)
    {
      if(password == null)
        throw new ArgumentNullException(nameof(password));
      if(username == null)
        throw new ArgumentNullException(nameof(username));

      var user = CreateUser();
      PopulateUsernameAndCredentials(user, username, password);
      Save(user);
    }

    protected virtual User CreateUser()
    {
      return userFactory();
    }

    protected virtual void PopulateUsernameAndCredentials(User user, string username, string password)
    {
      user.Username = username;
      user.SerializedCredentials = GetSerializedCredentials(password);
    }

    protected virtual void Save(User user)
    {
      repo.Add(user);
    }

    public UserCreator(IRepository<User> repo,
                       Func<User> userFactory,
                       ICredentialsCreator credentialsCreator,
                       ICredentialsSerializer credentialsSerializer)
      : base(credentialsCreator, credentialsSerializer)
    {
      if(userFactory == null)
        throw new ArgumentNullException(nameof(userFactory));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));

      this.repo = repo;
      this.userFactory = userFactory;
    }
  }
}
