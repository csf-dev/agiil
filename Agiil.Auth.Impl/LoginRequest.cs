using System;
namespace Agiil.Auth
{
  public class LoginRequest : ILoginRequest
  {
    #region fields

    readonly LoginCredentials credentials;
    readonly string sourceAddress;

    #endregion

    #region properties

    public LoginCredentials GetCredentials() => credentials;

    public string SourceAddress => sourceAddress;

    #endregion

    #region constructor

    public LoginRequest(LoginCredentials credentials, string sourceAddress) : this(credentials)
    {
      if(sourceAddress == null)
        throw new ArgumentNullException(nameof(sourceAddress));
      
      this.sourceAddress = sourceAddress;
    }

    public LoginRequest (LoginCredentials credentials)
    {
      if (credentials == null)
        throw new ArgumentNullException (nameof (credentials));
      
      this.credentials = credentials;
    }

    #endregion
  }
}
