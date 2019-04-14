using System;
using Agiil.Tests.Data;
using CSF.Data;
using CSF.Data.Entities;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public class InMemoryEntityDataCustomization : ICustomization
  {
    readonly bool generateIds;

    public void Customize(IFixture fixture)
    {
      fixture.Customize<IEntityData>(c => {
        return c.FromFactory(() => InMemoryEntityDataFactory.Default.GetEntityData(generateIds));
      });
    }

    public InMemoryEntityDataCustomization(bool generateIds)
    {
      this.generateIds = generateIds;
    }
  }
}
