using System;
using System.Linq;
using CSF.ORM;

namespace Agiil.Domain.Auth
{
  public class UserQueryByUsername : IGetsUserByUsername
  {
    readonly IEntityData repo;

    public User Get(string username)
    {
      if(username == null)
        throw new ArgumentNullException(nameof(username));

      return repo.Query<User>().FirstOrDefault(x => x.Username == username);
    }

    public UserQueryByUsername(IEntityData repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
