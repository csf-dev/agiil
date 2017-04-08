using System;
using System.Security.Principal;

namespace Agiil.Services.Auth
{
  public interface IIdentityReader
  {
    ICurrentUserInfo GetCurrentUserInfo();
  }
}
