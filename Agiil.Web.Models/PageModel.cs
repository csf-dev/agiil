using System;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class PageModel : IHasLoginState, IHasApplicationVersion
  {
    public LoginStateModel LoginState { get; set; }

    public ApplicationVersionInfo ApplicationVersion { get; set; }
  }
}
