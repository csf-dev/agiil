using System;
using CSF.Entities;

namespace Agiil.Auth
{
  public interface IUserUpdater
  {
    void ChangePassword(IIdentity userIdentity, string newPassword);
  }
}
