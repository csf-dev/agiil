using System;
using CSF.ORM;
using Moq;
using AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public class CreatesTransactionCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<IGetsTransaction>(c => c.FromFactory((ITransaction tran) => {
        return Mock.Of<IGetsTransaction>(x => x.GetTransaction() == tran);
      }));
    }
  }
}
