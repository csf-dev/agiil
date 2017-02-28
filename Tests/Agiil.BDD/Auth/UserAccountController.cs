using System;
using System.Linq;
using Agiil.BDD.Controllers.Auth;
using Agiil.Domain.Auth;
using CSF.Data;
using CSF.Data.Entities;
using Ploeh.AutoFixture;
using System.Security.Cryptography;
using Agiil.Tests.Common;

namespace Agiil.BDD.Impl.Auth
{
  public class UserAccountController : IUserAccountController
  {
    readonly InMemoryQuery query;
    readonly IFixture autoFixture;

    static readonly byte[] SALT = { 0, 10, 20, 30, 0, 10, 20, 30 };
    static readonly int ITERATION_COUNT = 256000, KEY_LENGTH = 32;

    public void AddUser(string username, string password)
    {
      var user = autoFixture.Create<User>();

      user.GenerateIdentity();
      user.Username = username;
      user.AuthenticationInfo = CreateAuthenticationInfo(password);

      query.Add(user);
    }

    public void RemoveUser(string username)
    {
      if(query.Query<User>().Any(x => x.Username == username))
      {
        throw new InvalidOperationException($"There must not be a user with username '{username}'.");
      }
    }

    private string CreateAuthenticationInfo(string password)
    {
      if(password == null)
      {
        throw new ArgumentNullException(nameof(password));
      }

      var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

      var utility = new Rfc2898DeriveBytes(passwordBytes, SALT, ITERATION_COUNT);
      var hash = utility.GetBytes(KEY_LENGTH);

      return String.Concat(Convert.ToBase64String(SALT), ":", Convert.ToBase64String(hash));
    }


    public UserAccountController (InMemoryQuery query, IFixture autoFixture)
    {
      if(autoFixture == null)
        throw new ArgumentNullException(nameof(autoFixture));
      if(query == null)
        throw new ArgumentNullException(nameof(query));
      
      this.query = query;
      this.autoFixture = autoFixture;
    }
  }
}
