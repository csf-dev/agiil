using System;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Tests.Data
{
  public class InMemoryEntityDataFactory
  {
    public IEntityData GetEntityData(bool generateIds = true)
    {
      var query = new InMemoryQuery();
      var persister = new InMemoryPersister(query);

      if(generateIds)
        return new IdentityGeneratingEntityData(query, persister);

      return new EntityData(query, persister);
    }

    public static InMemoryEntityDataFactory Default { get; private set; }

    static InMemoryEntityDataFactory()
    {
      Default = new InMemoryEntityDataFactory();
    }
  }
}
