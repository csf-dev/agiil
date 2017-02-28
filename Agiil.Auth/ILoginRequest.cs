using System;
namespace Agiil.Auth
{
  public interface ILoginRequest
  {
    LoginCredentials GetCredentials();
  }
}
