using System;
namespace Agiil.BDD.Controllers.Auth
{
  public interface IUserAccountController
  {
    void AddUser(string username, string password);

    void RemoveUser(string username);
  }
}
