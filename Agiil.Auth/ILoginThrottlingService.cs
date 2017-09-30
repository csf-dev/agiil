using System;
namespace Agiil.Auth
{
  public interface ILoginThrottlingService
  {
    LoginThrottlingResponse GetThrottlingResponse(ILoginRequest request);
  }
}
