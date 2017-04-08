using System;
using Agiil.Domain.Auth;
using Agiil.Services.Auth;
using Moq;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Common.Customizations
{
  public class LoggedInCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Freeze<User>();

      fixture.Customize<ICurrentUserReader>(c => {
        return c
          .FromFactory((User user) => {
            var output = Mock.Of<ICurrentUserReader>();
            Mock.Get(output).Setup(x => x.GetCurrentUser()).Returns(user);
            Mock.Get(output).Setup(x => x.RequireCurrentUser()).Returns(user);
            return output;
          });
      });
    }
  }
}
