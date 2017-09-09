using System;
namespace Agiil.Domain.Auth
{
  /// <summary>
  /// Service which gets a single user by their username.
  /// </summary>
  public interface IGetsUserByUsername
  {
    /// <summary>
    /// Gets the user if they exist, or a <c>null</c> reference if they do not.
    /// </summary>
    /// <param name="username">Username.</param>
    User Get(string username);
  }
}
