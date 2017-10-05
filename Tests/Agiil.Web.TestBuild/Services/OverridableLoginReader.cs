using System;
using Agiil.Auth;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Web.Services
{
  public class OverridableLoginReader : ClaimsIdentityReader, IOverridesCurrentLogin
  {
    ICurrentUserInfo overriddenUser;
    readonly IGetsUserByUsername userQuery;

    public void OverrideLogin(string username)
    {
      if(username == null)
        throw new ArgumentNullException(nameof(username));

      var user = userQuery.Get(username);
      if(user == null)
        throw new ArgumentException($"The user '{username}' does not exist.", nameof(username));

      overriddenUser = new UserInformation(user.GetIdentity(), user.Username);
    }

    public void ClearOverride()
    {
      overriddenUser = null;
    }

    public override ICurrentUserInfo GetCurrentUserInfo()
    {
      if(overriddenUser != null)
        return overriddenUser;

      return base.GetCurrentUserInfo();
    }

    public OverridableLoginReader(IPrincipalGetter principalGetter,
                                  IGetsUserByUsername userQuery) : base(principalGetter)
    {
      if(userQuery == null)
        throw new ArgumentNullException(nameof(userQuery));

      this.userQuery = userQuery;
    }
  }
}
