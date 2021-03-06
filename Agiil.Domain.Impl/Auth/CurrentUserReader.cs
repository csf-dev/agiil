﻿using System;
using CSF.ORM;

namespace Agiil.Domain.Auth
{
  public class CurrentUserReader : ICurrentUserReader
  {
    readonly IIdentityReader identityReader;
    readonly IEntityData query;

    public User GetCurrentUser()
    {
      var userInfo = GetUserInfo();
      if(userInfo == null)
      {
        return null;
      }
      return GetUser(userInfo);
    }

    public User RequireCurrentUser()
    {
      var userInfo = GetUserInfo();
      if(userInfo == null)
      {
        throw new CurrentUserNotIdentifiedException(Resources.ExceptionMessages.UserMustBeLoggedIn);
      }
      var user = GetUser(userInfo);
      if(user == null)
      {
        throw new CurrentUserNotIdentifiedException(Resources.ExceptionMessages.UserMustExist);
      }
      return user;
    }

    protected ICurrentUserInfo GetUserInfo()
    {
      return identityReader.GetCurrentUserInfo();
    }

    protected User GetUser(ICurrentUserInfo userInfo)
    {
      return query.Get(userInfo.Identity);
    }

    public CurrentUserReader(IIdentityReader identityReader, IEntityData query)
    {
      if(query == null)
        throw new ArgumentNullException(nameof(query));
      if(identityReader == null)
        throw new ArgumentNullException(nameof(identityReader));
      
      this.query = query;
      this.identityReader = identityReader;
    }
  }
}
