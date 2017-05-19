using System;
using CSF.Entities;

namespace Agiil.Auth
{
  public interface IUserPasswordUpdater
  {
    void ChangePassword(object user, string newPassword);
  }
}
