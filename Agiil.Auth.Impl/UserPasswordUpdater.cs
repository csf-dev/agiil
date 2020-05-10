using System;
using Agiil.Domain.Auth;
using CSF.ORM;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class UserPasswordUpdater : UserPasswordSetterBase, IUserPasswordUpdater
  {
    readonly IEntityData repo;

    public void ChangePassword(User user, string newPassword)
    {
      if(newPassword == null)
        throw new ArgumentNullException(nameof(newPassword));
      if(user == null)
        throw new ArgumentNullException(nameof(user));

      user.SerializedCredentials = GetSerializedCredentials(newPassword);
      Save(user);
    }

    protected virtual void Save(User user)
    {
      repo.Update(user);
    }

    void IUserPasswordUpdater.ChangePassword(object user, string newPassword)
    {
      ChangePassword((User) user, newPassword);
    }

    public UserPasswordUpdater(ICredentialsCreator credentialsCreator,
                       ICredentialsSerializer credentialsSerializer,
                       IEntityData repo)
      : base(credentialsCreator, credentialsSerializer)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
