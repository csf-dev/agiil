using System;
using CSF.ORM;

namespace Agiil.Tests.Data.Persistence
{
    public class CachingDataConnectionFactoryAdapter : IGetsDataConnection, IDisposable
    {
        readonly IGetsDataConnection wrapped;
        IDataConnection connection;
        bool disposedValue;

        public IDataConnection GetConnection()
        {
            if(connection == null)
                connection = wrapped.GetConnection();

            return new NoDisposalDataConnectionDecorator(connection);
        }

        public CachingDataConnectionFactoryAdapter(IGetsDataConnection wrapped)
        {
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                    connection?.Dispose();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        #region Contained type

        class NoDisposalDataConnectionDecorator : IDataConnection
        {
            readonly IDataConnection wrapped;

            public void Dispose() { /* Intentional no-op */ }

            public void EvictFromCache(object objectToEvict) => wrapped.EvictFromCache(objectToEvict);

            public IPersister GetPersister() => wrapped.GetPersister();

            public IQuery GetQuery() => wrapped.GetQuery();

            public IGetsTransaction GetTransactionFactory() => wrapped.GetTransactionFactory();

            public NoDisposalDataConnectionDecorator(IDataConnection wrapped)
            {
                this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
            }
        }

        #endregion
    }
}
