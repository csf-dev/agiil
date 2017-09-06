using System;
namespace Agiil.Web.Services
{
  public interface IOverridesCurrentLogin
  {
    void ClearOverride();

    void OverrideLogin(string username);
  }
}
