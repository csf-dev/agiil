using System;
using CSF.Data;
using CSF.Security.Authentication;
using CSF.Data.Entities;
using Agiil.Domain.Auth;
using System.Linq;
using CSF.Entities;

namespace Agiil.Auth
{
  public class UserCredentialsRepository : IStoredCredentialsRepository
  {
    #region fields

    readonly IQuery query;

    #endregion

    #region methods

    public StoredUserInformation GetStoredCredentials(LoginCredentials enteredCredentials)
    {
      if(enteredCredentials == null)
      {
        throw new ArgumentNullException(nameof(enteredCredentials));
      }

      var userAccount = GetUserAccount(enteredCredentials);

      if(userAccount == null)
      {
        return null;
      }

      return new StoredUserInformation {
        SerializedCredentials = userAccount.SerializedCredentials,
        UserInformation = new UserInformation(userAccount.GetIdentity(), userAccount.Username),
      };
    }

    User GetUserAccount(LoginCredentials enteredCredentials)
    {
      return query.Query<User>().SingleOrDefault(x => x.Username == enteredCredentials.Username);
    }

    IStoredCredentials IStoredCredentialsRepository.GetStoredCredentials (IPassword enteredCredentials)
    {
      return GetStoredCredentials(enteredCredentials as LoginCredentials);
    }

    #endregion

    #region constructor

    public UserCredentialsRepository (IQuery query)
    {
      if (query == null)
        throw new ArgumentNullException (nameof (query));
      
      this.query = query;
    }

    #endregion
  }
}
