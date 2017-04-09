using System;

namespace Agiil.Domain.Auth
{
  public interface ICurrentUserReader
  {
    User RequireCurrentUser();

    User GetCurrentUser();
  }
}
