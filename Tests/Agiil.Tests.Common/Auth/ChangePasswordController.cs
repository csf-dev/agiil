using System;
using Agiil.Web.Models;

namespace Agiil.Tests.Auth
{
  public class ChangePasswordController : IChangePasswordController
  {
    readonly Web.Controllers.ChangePasswordController webController;

    public void ChangePassword(ChangePasswordSpecification spec)
    {
      webController.Change(spec);
    }

    public ChangePasswordController(Web.Controllers.ChangePasswordController webController)
    {
      if(webController == null)
        throw new ArgumentNullException(nameof(webController));
      this.webController = webController;
    }
  }
}
