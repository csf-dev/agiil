using System;
namespace Agiil.Web.Models.Shared
{
  public interface IHasLoginState
  {
    LoginStateModel LoginState { get; set; }
  }
}
