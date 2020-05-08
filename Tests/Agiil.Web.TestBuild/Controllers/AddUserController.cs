using System;
using System.Web.Http;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Web.Models;
using CSF.ORM;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class AddUserController : ApiController
  {
    readonly IUserCreator userCreator;
    readonly IGetsUserByUsername userQuery;
    readonly IUserPasswordUpdater passwordChanger;
    readonly IGetsTransaction transactionCreator;

    public IHttpActionResult Post(CreateUserModel model)
    {
      if(model == null)
        throw new ArgumentNullException(nameof(model));

      bool exists;

      using(var tran = transactionCreator.GetTransaction())
      {
        var existingUser = userQuery.Get(model.username);

        if(existingUser == null)
        {
          userCreator.Add(model.username, model.password);
          exists = false;
        }
        else
        {
          passwordChanger.ChangePassword(existingUser, model.password);
          exists = true;
        }

        tran.Commit();
      }

      return Ok(exists? $"The existing user '{model.username}' was updated" : $"The user '{model.username}' was created");
    }

    public AddUserController(IUserCreator userCreator,
                             IGetsUserByUsername userQuery,
                             IUserPasswordUpdater passwordChanger,
                             IGetsTransaction transactionCreator)
    {
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(passwordChanger == null)
        throw new ArgumentNullException(nameof(passwordChanger));
      if(userQuery == null)
        throw new ArgumentNullException(nameof(userQuery));
      if(userCreator == null)
        throw new ArgumentNullException(nameof(userCreator));
      
      this.userCreator = userCreator;
      this.passwordChanger = passwordChanger;
      this.userQuery = userQuery;
      this.transactionCreator = transactionCreator;
    }
  }
}
