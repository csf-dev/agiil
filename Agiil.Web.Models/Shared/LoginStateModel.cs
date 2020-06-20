using System;
using Agiil.Domain.Auth;

namespace Agiil.Web.Models.Shared
{
    public class LoginStateModel
    {
        public ICurrentUserInfo UserInfo { get; set; }

        public bool IsSiteAdmin { get; set; }

        public string Username => UserInfo?.Username;

        public string UserIdentity => UserInfo?.Identity?.GetValueAsString();

        public bool IsLoggedIn => UserInfo != null;
    }
}
