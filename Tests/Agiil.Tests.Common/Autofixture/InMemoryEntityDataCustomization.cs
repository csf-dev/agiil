using System;
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
        return c.FromFactory(() => {
          var query = new InMemoryQuery();
          var persister = new InMemoryPersister(query);

          if(generateIds)
            return new IdentityGeneratingEntityData(query, persister);
          
          return new EntityData(query, persister);
        });
      });
    }

    public InMemoryEntityDataCustomization(bool generateIds)
    {
      this.generateIds = generateIds;
    }
  }
}
