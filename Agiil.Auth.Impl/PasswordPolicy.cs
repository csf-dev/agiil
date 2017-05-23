using System;
using Agiil.Domain.Auth;
using System.Text.RegularExpressions;

namespace Agiil.Auth
{
  public class PasswordPolicy : IPasswordPolicy
  {
    public bool IsPasswordOk(string password, User user)
    {
      if(user == null)
        throw new ArgumentNullException(nameof(user));
      if(ReferenceEquals(password, null))
        return false;

      if(password.Length < 6)
        return false;

      return true;
    }

    bool IPasswordPolicy.IsPasswordOk(string password, object user)
    {
      return IsPasswordOk(password, (User) user);
    }
  }
}
