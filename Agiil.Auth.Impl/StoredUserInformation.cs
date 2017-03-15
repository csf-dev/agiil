using System;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class StoredUserInformation : IStoredCredentials
  {
    public string SerializedCredentials { get; set; }

    public UserInformation UserInformation { get; set; }
  }
}
