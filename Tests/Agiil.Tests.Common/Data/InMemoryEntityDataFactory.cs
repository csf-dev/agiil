using System;
using CSF.ORM;
using CSF.ORM.InMemory;

namespace Agiil.Tests.Data
{
    public class InMemoryEntityDataFactory
    {
        public IEntityData GetEntityData(bool generateIds = true)
        {
            var store = new DataStore();
            var query = new DataQuery(store);
            IPersister persister = new DataPersister(store);

            if(generateIds)
                persister = new IdentityGeneratingPersisterDecorator(persister);

            return new EntityData(query, persister);
        }

        public static InMemoryEntityDataFactory Default { get; private set; }

        static InMemoryEntityDataFactory()
        {
            Default = new InMemoryEntityDataFactory();
        }
    }
}
