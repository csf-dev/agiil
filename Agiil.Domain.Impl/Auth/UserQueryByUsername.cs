using System;
using System.Linq;
using CSF.Data.Entities;

namespace Agiil.Domain.Auth
{
  public class UserQueryByUsername : IGetsUserByUsername
  {
    readonly IRepository<User> repo;

    public User Get(string username)
    {
      if(username == null)
        throw new ArgumentNullException(nameof(username));

      return repo.Query().FirstOrDefault(x => x.Username == username);
    }

    public UserQueryByUsername(IRepository<User> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
