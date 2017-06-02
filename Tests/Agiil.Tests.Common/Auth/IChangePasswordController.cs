using System;
using Agiil.Web.Models.Auth;

namespace Agiil.Tests.Auth
{
  public interface IChangePasswordController
  {
    void ChangePassword(ChangePasswordSpecification spec);
  }
}
