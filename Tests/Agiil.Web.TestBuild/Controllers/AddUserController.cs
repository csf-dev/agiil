using System;
using System.Web.Http;
using Agiil.Auth;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class AddUserController : ApiController
  {
    readonly IUserCreator userCreator;

    public IHttpActionResult Post(string username, string password)
    {
      userCreator.Add(username, password);
      return Ok();
    }

    public AddUserController(IUserCreator userCreator)
    {
      if(userCreator == null)
        throw new ArgumentNullException(nameof(userCreator));
      
      this.userCreator = userCreator;
    }
  }
}
