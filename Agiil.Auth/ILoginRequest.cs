using System;
namespace Agiil.Auth
{
  public interface ILoginRequest
  {
    /// <summary>
    /// A string which identifies the source of the login attempt.  For example in a web application, this could be
    /// the IP address of the remote host performing the login attempt.
    /// </summary>
    string SourceAddress { get; }

    LoginCredentials GetCredentials();
  }
}
