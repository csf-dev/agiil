using System;
namespace Agiil.Web.OAuth
{
  public interface IOAuthAuthorizationChecker
  {
    void CheckAuthentication(object context);
  }
}
