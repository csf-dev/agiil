using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Agiil.Web.App_Start
{
  public class AuthConfig
  {
    public void Configure(IAppBuilder builder)
    {
      builder.UseCookieAuthentication(new CookieAuthenticationOptions
      {
        AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
        LoginPath = new PathString($"/Login/Index"),
        SlidingExpiration = true,
        ExpireTimeSpan = TimeSpan.FromHours(8),
      });
    }
  }
}
