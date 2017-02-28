using System;
namespace Agiil.Auth
{
  public class LogoutResult
  {
    readonly bool success;
    static readonly LogoutResult logoutSuccessful;

    public bool Success => success;

    LogoutResult(bool success)
    {
      this.success = success;
    }

    static LogoutResult()
    {
      logoutSuccessful = new LogoutResult(true);
    }

    public static LogoutResult LogoutSuccessful => logoutSuccessful;
  }
}
