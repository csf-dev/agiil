using System;
using System.Security.Principal;

namespace Agiil.Domain.Auth
{
  public interface IIdentityReader
  {
    ICurrentUserInfo GetCurrentUserInfo();
  }
}
