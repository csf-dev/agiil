using System;
namespace Agiil.Auth
{
  public interface IPasswordChanger
  {
    PasswordChangeResponse ChangeOwnPassword(PasswordChangeRequest request);
  }
}
