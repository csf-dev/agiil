using System;
namespace Agiil.Tests.Auth
{
  public interface IUserAccountController
  {
    void AddUser(string username, string password);

    void RemoveUser(string username);
  }
}
