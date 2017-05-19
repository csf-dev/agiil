using System;
using Agiil.Domain.Auth;
using CSF.Data;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class PasswordChanger : IPasswordChanger
  {
    readonly IUserPasswordUpdater updater;
    readonly ICurrentUserReader userReader;
    readonly IPasswordAuthenticationService authService;
    readonly IPasswordPolicy policy;
    readonly ITransactionCreator transactionCreator;

    public PasswordChangeResponse ChangeOwnPassword(PasswordChangeRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));

      using(var tran = transactionCreator.BeginTransaction())
      {
        var user = userReader.RequireCurrentUser();
        if(!IsExistingPasswordCorrect(request.ExistingPassword, user))
          return new PasswordChangeResponse { ExistingPasswordIncorrect = true };

        if(request.ConfirmNewPassword != request.NewPassword)
          return new PasswordChangeResponse { NewPasswordDoesNotMatchConfirmation = true };

        if(!policy.IsPasswordOk(request.NewPassword, user))
          return new PasswordChangeResponse { NewPasswordDoesNotSatisfyPolicy = true };

        updater.ChangePassword(user, request.NewPassword);
        tran.Commit();
      }

      return new PasswordChangeResponse();
    }

    bool IsExistingPasswordCorrect(string password, User user)
    {
      var credentials = new LoginCredentials
      {
        Password = password,
        Username = user.Username,
      };
      return authService.Authenticate(credentials).Success;
    }

    public PasswordChanger(IPasswordPolicy policy,
                           IPasswordAuthenticationService authService,
                           ICurrentUserReader userReader,
                           IUserPasswordUpdater updater,
                           ITransactionCreator transactionCreator)
    {
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(updater == null)
        throw new ArgumentNullException(nameof(updater));
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(authService == null)
        throw new ArgumentNullException(nameof(authService));
      if(policy == null)
        throw new ArgumentNullException(nameof(policy));
      this.policy = policy;
      this.authService = authService;
      this.userReader = userReader;
      this.updater = updater;
      this.transactionCreator = transactionCreator;
    }
  }
}
