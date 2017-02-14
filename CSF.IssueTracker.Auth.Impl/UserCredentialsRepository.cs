using System;
using CSF.Data;
using CSF.Security;
using CSF.Data.Entities;
using CSF.IssueTracker.Domain.Auth;
using System.Linq;

namespace CSF.IssueTracker.Auth
{
  public class UserCredentialsRepository : ICredentialsRepository
  {
    #region fields

    readonly IQuery query;
    readonly IKeyAndSaltConverter converter;

    #endregion

    #region methods

    public object GetStoredCredentials (object enteredCredentials)
    {
      return GetStoredCredentials(enteredCredentials as LoginCredentials);
    }

    public IStoredCredentialsWithKeyAndSalt GetStoredCredentials (LoginCredentials enteredCredentials)
    {
      if (enteredCredentials == null) {
        throw new ArgumentNullException (nameof (enteredCredentials));
      }

      var user = GetUser(enteredCredentials.Username);

      if(user == null)
      {
        return null;
      }

      return converter.GetKeyAndSalt(user.AuthenticationInfo);
    }

    private User GetUser(string username)
    {
      return query.Query<User>().SingleOrDefault(x => x.Username == username);
    }

    #endregion

    #region constructor

    public UserCredentialsRepository (IQuery query, IKeyAndSaltConverter converter)
    {
      if (converter == null)
        throw new ArgumentNullException (nameof (converter));
      if (query == null)
        throw new ArgumentNullException (nameof (query));
      
      this.converter = converter;
      this.query = query;
    }

    #endregion
  }
}
