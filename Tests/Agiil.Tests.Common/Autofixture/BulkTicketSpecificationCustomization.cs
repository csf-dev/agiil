using System;
using Agiil.Tests.Tickets;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public class BulkTicketSpecificationCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<BulkTicketSpecification>(c => {
        c.Without(x => x.Id);
        return c;
      });
    }
  }
}
