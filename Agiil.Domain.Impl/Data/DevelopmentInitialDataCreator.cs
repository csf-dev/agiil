using System;
using Agiil.Domain.Auth;
using CSF.Data.Entities;

namespace Agiil.Domain.Data
{
  public class DevelopmentInitialDataCreator : IInitialDataCreator
  {
    readonly IRepository<User> userRepo;

    public void Create()
    {
      CreateInitialUser();
    }

    void CreateInitialUser()
    {
      var user = new User
      {
        Username = "admin",
        SerializedCredentials = "AAoUHgAKFB4=:/Rio8u8kWL4yictmVX/B0xO1G8q8xDUyv2Xce7Qvw/Q=",
      };
      userRepo.Add(user);
    }

    public DevelopmentInitialDataCreator(IRepository<User> userRepo)
    {
      if(userRepo == null)
        throw new ArgumentNullException(nameof(userRepo));

      this.userRepo = userRepo;
    }
  }
}
