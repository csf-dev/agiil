using System;
using System.Linq;
using Agiil.BDD.Controllers.Auth;
using Agiil.Domain.Auth;
using CSF.Data;
using CSF.Data.Entities;
using Ploeh.AutoFixture;
using System.Security.Cryptography;
using Agiil.Tests.Common;
using CSF.Security.Authentication;

namespace Agiil.BDD.Impl.Auth
{
  public class InMemoryUserAccountController : IUserAccountController
  {
    readonly InMemoryQuery query;
    readonly IFixture autoFixture;
    readonly ICredentialsCreator credentialsCreator;
    readonly ICredentialsSerializer credentialsSerializer;

    public void AddUser(string username, string password)
    {
      var user = autoFixture.Create<User>();

      user.GenerateIdentity();
      user.Username = username;
      user.SerializedCredentials = GetSerializedCredentials(password);

      query.Add(user);
    }

    public void RemoveUser(string username)
    {
      if(query.Query<User>().Any(x => x.Username == username))
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


    public InMemoryUserAccountController (InMemoryQuery query,
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
      if(query == null)
        throw new ArgumentNullException(nameof(query));
      
      this.query = query;
      this.autoFixture = autoFixture;
      this.credentialsCreator = credentialsCreator;
      this.credentialsSerializer = credentialsSerializer;
    }
  }
}
