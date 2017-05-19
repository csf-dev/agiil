using System;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public abstract class UserPasswordSetterBase
  {
    readonly ICredentialsCreator credentialsCreator;
    readonly ICredentialsSerializer credentialsSerializer;

    protected virtual string GetSerializedCredentials(string password)
    {
      if(password == null)
      {
        throw new ArgumentNullException(nameof(password));
      }

      var credentialsObject = credentialsCreator.CreateCredentials(new CredentialsWithPassword { Password = password });
      return credentialsSerializer.Serialize(credentialsObject);
    }

    public UserPasswordSetterBase(ICredentialsCreator credentialsCreator,
                                  ICredentialsSerializer credentialsSerializer)
    {
      if(credentialsSerializer == null)
        throw new ArgumentNullException(nameof(credentialsSerializer));
      if(credentialsCreator == null)
        throw new ArgumentNullException(nameof(credentialsCreator));

      this.credentialsCreator = credentialsCreator;
      this.credentialsSerializer = credentialsSerializer;
    }
  }
}
