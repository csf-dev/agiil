using System;
using Agiil.Tests.Sprints;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public class BulkSprintCreationSpecificationCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<BulkSprintCreationSpecification>(c => {
        return c
          .Without(x => x.Id);
      });
    }
  }
}
