using System;
namespace Agiil.BDD.Controllers.Auth
{
  public interface ILoginController
  {
    void Login(string username, string password);
  }
}
