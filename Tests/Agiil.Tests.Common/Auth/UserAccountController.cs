using System;
using System.Linq;
using Agiil.Auth;
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
    readonly IUserCreator userCreator;

    public void AddUser(string username, string password)
    {
      userCreator.Add(username, password);
    }

    public void RemoveUser(string username)
    {
      var existing = repo.Query().FirstOrDefault(x => x.Username == username);
      if(existing != null)
      {
        repo.Remove(existing);
      }
    }

    public UserAccountController (IRepository<User> repo,
                                  IUserCreator userCreator)
    {
      if(userCreator == null)
        throw new ArgumentNullException(nameof(userCreator));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      
      this.repo = repo;
      this.userCreator = userCreator;
    }
  }
}
