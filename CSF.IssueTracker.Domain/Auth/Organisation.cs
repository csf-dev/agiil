using System;
using System.Collections.Generic;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace CSF.IssueTracker.Domain.Auth
{
  public class Organisation : Entity<long>
  {
    #region fields

    private ISet<User> _users;
    EventRaisingSetWrapper<User> _wrappedUsers;

    #endregion

    #region properties

    public virtual ISet<User> Users => _wrappedUsers.Collection;

    #endregion

    #region constructors

    public Organisation ()
    {
      _users = new HashSet<User>();
      _wrappedUsers = new EventRaisingSetWrapper<User>(_users);

      _wrappedUsers.AfterAdd += (sender, e) => e.Item.Organisation = this;
      _wrappedUsers.AfterRemove += (sender, e) => e.Item.Organisation = null;
    }

    #endregion
  }
}
