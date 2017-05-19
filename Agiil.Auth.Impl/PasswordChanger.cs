using System;
using Agiil.Domain.Auth;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class PasswordChanger : IPasswordChanger
  {
    readonly IUserUpdater updater;
    readonly IIdentityReader identityReader;
    readonly IPasswordAuthenticationService authService;
    readonly IPasswordPolicy policy;

    public PasswordChangeResponse ChangeOwnPassword(PasswordChangeRequest request)
    {
      throw new NotImplementedException();
    }

    public PasswordChanger(IPasswordPolicy policy,
                           IPasswordAuthenticationService authService,
                           IIdentityReader identityReader,
                           IUserUpdater updater)
    {
      if(updater == null)
        throw new ArgumentNullException(nameof(updater));
      if(identityReader == null)
        throw new ArgumentNullException(nameof(identityReader));
      if(authService == null)
        throw new ArgumentNullException(nameof(authService));
      if(policy == null)
        throw new ArgumentNullException(nameof(policy));
      this.policy = policy;
      this.authService = authService;
      this.identityReader = identityReader;
      this.updater = updater;
    }
  }
}
