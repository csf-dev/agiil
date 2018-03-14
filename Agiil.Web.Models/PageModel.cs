using System;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class PageModel : IHasLoginState
  {
    public LoginStateModel LoginState { get; set; }
  }
}
