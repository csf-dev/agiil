using System;
using Agiil.Domain.Auth;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Services.Auth
{
  public class LoginStateReader
  {
    readonly IIdentityReader userReader;

    public LoginStateModel GetLoginState()
    {
      var userInfo = userReader.GetCurrentUserInfo();

      return new LoginStateModel
      {
        UserInfo = userInfo
      };
    }

    public LoginStateReader(IIdentityReader userReader)
    {
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      this.userReader = userReader;
    }
  }
}
