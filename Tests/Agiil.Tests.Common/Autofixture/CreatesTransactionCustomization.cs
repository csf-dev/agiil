using System;
using CSF.Data;
using Moq;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public class CreatesTransactionCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<ITransactionCreator>(c => c.FromFactory((ITransaction tran) => {
        return Mock.Of<ITransactionCreator>(x => x.BeginTransaction() == tran);
      }));
    }
  }
}
