using System;
using CSF.Entities;

namespace Agiil.Auth
{
  public interface ILogsUserInOrOut
  {
    void LogUserIn(IAuthenticationResult result);

    void LogUserIn(string username, IIdentity userIdentity);

    void LogUserOut();
  }
}
