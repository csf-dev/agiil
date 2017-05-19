using System;
namespace Agiil.Tests.Auth
{
  public interface ILoginController
  {
    void Login(string username, string password);

    void Logout();
  }
}
