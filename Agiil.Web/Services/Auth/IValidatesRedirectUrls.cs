using System;
namespace Agiil.Web.Services.Auth
{
  public interface IValidatesRedirectUrls
  {
    bool IsValid(string redirectUri);
    bool IsValid(Uri redirectUri);
  }
}
