using System;
using Agiil.Auth;
using Agiil.Domain.Auth;
using CSF.Data.Entities;

namespace Agiil.Domain.Data
{
  public class DevelopmentInitialDataCreator : IInitialDataCreator
  {
    readonly IUserCreator userCreator;

    public void Create()
    {
      CreateInitialUser();
    }

    void CreateInitialUser()
    {
      userCreator.Add("admin", "secret");
    }

    public DevelopmentInitialDataCreator(IUserCreator userCreator)
    {
      if(userCreator == null)
        throw new ArgumentNullException(nameof(userCreator));

      this.userCreator = userCreator;
    }
  }
}
