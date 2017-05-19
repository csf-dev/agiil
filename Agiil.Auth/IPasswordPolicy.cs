using System;
using CSF.Entities;

namespace Agiil.Auth
{
  public interface IPasswordPolicy
  {
    bool IsPasswordOk(string password, IIdentity userIdentity);
  }
}
