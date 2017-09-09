using System;
using System.Web.Http;
using Agiil.Auth;
using Agiil.Domain.Auth;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class AddUserController : ApiController
  {
    readonly IUserCreator userCreator;
    readonly IGetsUserByUsername userQuery;
    readonly IUserPasswordUpdater passwordChanger;

    public IHttpActionResult Post(string username, string password)
    {
      if(username == null)
        throw new ArgumentNullException(nameof(username));
      if(password == null)
        throw new ArgumentNullException(nameof(password));

      var existingUser = userQuery.Get(username);
      if(existingUser == null)
      {
        userCreator.Add(username, password);
      }
      else
      {
        passwordChanger.ChangePassword(existingUser, password);
      }
      
      return Ok();
    }

    public AddUserController(IUserCreator userCreator,
                             IGetsUserByUsername userQuery,
                             IUserPasswordUpdater passwordChanger)
    {
      if(passwordChanger == null)
        throw new ArgumentNullException(nameof(passwordChanger));
      if(userQuery == null)
        throw new ArgumentNullException(nameof(userQuery));
      if(userCreator == null)
        throw new ArgumentNullException(nameof(userCreator));
      
      this.userCreator = userCreator;
      this.passwordChanger = passwordChanger;
      this.userQuery = userQuery;
    }
  }
}
