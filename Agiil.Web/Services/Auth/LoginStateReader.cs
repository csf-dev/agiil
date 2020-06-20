using System;
using Agiil.Domain.Auth;
using Agiil.Web.Models.Shared;
using CSF.ORM;

namespace Agiil.Web.Services.Auth
{
    public class LoginStateReader
    {
        readonly IIdentityReader userReader;
        readonly IEntityData data;

        public LoginStateModel GetLoginState()
        {
            var userInfo = userReader.GetCurrentUserInfo();

            return new LoginStateModel {
                UserInfo = userInfo,
                IsSiteAdmin = (userInfo != null)? data.Get(userInfo.Identity).SiteAdministrator : false,
            };
        }

        public LoginStateReader(IIdentityReader userReader, IEntityData data)
        {
            this.userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
