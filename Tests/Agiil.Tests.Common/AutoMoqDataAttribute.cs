using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Common
{
#pragma warning disable CS1702 // Assuming assembly reference matches identity
  public class AutoMoqDataAttribute : AutoDataAttribute
  {
    public AutoMoqDataAttribute() : base(new Fixture().Customize(new AutoMoqCustomization()))
    {
    }
  }
  #pragma warning restore CS1702 // Assuming assembly reference matches identity
}
