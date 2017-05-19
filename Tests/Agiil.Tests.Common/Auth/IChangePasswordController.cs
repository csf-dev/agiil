using System;
using Agiil.Web.Models;

namespace Agiil.Tests.Auth
{
  public interface IChangePasswordController
  {
    void ChangePassword(ChangePasswordSpecification spec);
  }
}
