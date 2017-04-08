using System;
using Agiil.Domain.Auth;

namespace Agiil.Services.Auth
{
  public interface ICurrentUserReader
  {
    User RequireCurrentUser();

    User GetCurrentUser();
  }
}
