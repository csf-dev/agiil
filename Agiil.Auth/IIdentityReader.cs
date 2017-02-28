using System;
using System.Security.Principal;

namespace Agiil.Auth
{
  public interface IIdentityReader
  {
    ICurrentUserInfo GetCurrentUserInfo();
  }
}
