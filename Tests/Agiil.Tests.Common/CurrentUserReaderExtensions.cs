using System;
using Agiil.Domain.Auth;
using Moq;

namespace Agiil.Tests
{
  public static class CurrentUserReaderExtensions
  {
    public static void SetupCurrentUser(this ICurrentUserReader reader, User user)
    {
      if(reader == null)
      {
        throw new ArgumentNullException(nameof(reader));
      }

      Mock.Get(reader)
          .Setup(x => x.GetCurrentUser())
          .Returns(user);
      Mock.Get(reader)
          .Setup(x => x.RequireCurrentUser())
          .Returns(user);
    }
  }
}
