using System;
using System.Linq;
using Agiil.Auth;
using Agiil.Domain.Auth;
using CSF.Data;
using CSF.Entities;

namespace Agiil.Web.Services
{
  public class OverridableLoginReader : ClaimsIdentityReader, IOverridesCurrentLogin
  {
    IQuery query;
    ICurrentUserInfo overriddenUser;

    public void OverrideLogin(string username)
    {
      if(username == null)
        throw new ArgumentNullException(nameof(username));

      var user = query.Query<User>().FirstOrDefault(x => x.Username == username);
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
                                  IQuery query) : base(principalGetter)
    {
      if(query == null)
        throw new ArgumentNullException(nameof(query));

      this.query = query;
    }
  }
}
