using System;
namespace Agiil.Auth
{
  public class LoginRequest : ILoginRequest
  {
    #region fields

    readonly LoginCredentials credentials;

    #endregion

    #region properties

    public LoginCredentials GetCredentials() => credentials;

    #endregion

    #region constructor

    public LoginRequest (LoginCredentials credentials)
    {
      if (credentials == null)
        throw new ArgumentNullException (nameof (credentials));
      
      this.credentials = credentials;
    }

    #endregion
  }
}
