using System;
using System.Linq;
using Agiil.Domain.Auth;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Security.Authentication;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Auth
{
  public class UserAccountController : IUserAccountController
  {
    readonly IRepository<User> repo;
    readonly IFixture autoFixture;
    readonly ICredentialsCreator credentialsCreator;
    readonly ICredentialsSerializer credentialsSerializer;

    public void AddUser(string username, string password)
    {
      var user = autoFixture.Create<User>();

      user.GenerateIdentity();
      user.Username = username;
      user.SerializedCredentials = GetSerializedCredentials(password);

      repo.Add(user);
    }

    public void RemoveUser(string username)
    {
      if(repo.Query().Any(x => x.Username == username))
      {
        throw new InvalidOperationException($"There must not be a user with username '{username}'.");
      }
    }

    private string GetSerializedCredentials(string password)
    {
      if(password == null)
      {
        throw new ArgumentNullException(nameof(password));
      }

      var credentialsObject = credentialsCreator.CreateCredentials(new CredentialsWithPassword { Password = password });
      return credentialsSerializer.Serialize(credentialsObject);
    }


    public UserAccountController (IRepository<User> repo,
                                          IFixture autoFixture,
                                          ICredentialsCreator credentialsCreator,
                                          ICredentialsSerializer credentialsSerializer)
    {
      if(credentialsSerializer == null)
        throw new ArgumentNullException(nameof(credentialsSerializer));
      if(credentialsCreator == null)
        throw new ArgumentNullException(nameof(credentialsCreator));
      if(autoFixture == null)
        throw new ArgumentNullException(nameof(autoFixture));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      
      this.repo = repo;
      this.autoFixture = autoFixture;
      this.credentialsCreator = credentialsCreator;
      this.credentialsSerializer = credentialsSerializer;
    }
  }
}
