using System;
namespace Agiil.Auth
{
  public interface IUserCreator
  {
    /// <summary>
    /// Creates and adds a user with the given username and password to the application.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    void Add(string username, string password);
  }
}
