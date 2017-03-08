using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Owin.Security.AesDataProtectorProvider;
using Microsoft.AspNet.Identity;

namespace Agiil.Web.App_Start
{
  public class AuthConfig
  {
    public void Configure(IAppBuilder builder)
    {
      builder.UseCookieAuthentication(new CookieAuthenticationOptions
      {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString($"/Login"),
      });

      builder.UseAesDataProtectorProvider();

      builder.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    }
  }
}
