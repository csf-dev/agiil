using System;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Auth;

namespace Agiil.Web.ActionFilters
{
    public class RequireAppAdminAttribute : AuthorizeAttribute
    {
        public ICurrentUserReader UserReader { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(!base.AuthorizeCore(httpContext)) return false;

            var currentUser = UserReader.GetCurrentUser();
            return currentUser?.SiteAdministrator == true;
        }
    }
}
