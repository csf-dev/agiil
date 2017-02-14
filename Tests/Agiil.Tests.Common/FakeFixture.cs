using NUnit.Framework;
using System;
namespace Agiil.Tests.Common
{
  [TestFixture]
  public class FakeFixture
  {
    [Test]
    public void DummyTestCase ()
    {
      Assert.Pass("This is a fake testcase");
    }
  }
}
