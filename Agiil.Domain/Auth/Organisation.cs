using System;
using System.Collections.Generic;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace CSF.IssueTracker.Domain.Auth
{
  public class Organisation : Entity<long>
  {
    #region fields

    readonly EventRaisingSetWrapper<User> _wrappedUsers;

    #endregion

    #region properties

    public virtual ISet<User> Users => _wrappedUsers.Collection;

    protected virtual ISet<User> SourceUsers {
      get {
        return _wrappedUsers.SourceCollection;
      }
      set {
        _wrappedUsers.SourceCollection = value;
      }
    }

    #endregion

    #region constructors

    public Organisation()
    {
      _wrappedUsers = new EventRaisingSetWrapper<User>();

      _wrappedUsers.AfterAdd += (sender, e) => e.Item.Organisation = this;
      _wrappedUsers.AfterRemove += (sender, e) => e.Item.Organisation = null;
    }

    #endregion
  }
}
