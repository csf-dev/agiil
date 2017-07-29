using System;
using Agiil.Domain.Data;
using Agiil.Tests;
using Autofac;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Web.TestBuild
{
  public class InMemoryDatabase
  {
    #region fields

    readonly object syncRoot;
    InMemoryQuery dataStore;

    #endregion

    #region methods

    internal InMemoryQuery GetDataStore()
    {
      CreateDataStoreIfRequired();
      return dataStore;
    }

    public void Reset()
    {
      Clear();
      AddTestData();
    }

    public void Clear()
    {
      dataStore = null;
    }

    public void AddTestData()
    {
      using(var scope = ApplicationContainer.Current.BeginLifetimeScope())
      {
        var dataCreator = scope.Resolve<IInitialDataCreator>();
        dataCreator.Create();
      }
    }

    internal IRepository<T> GetRepository<T>()
      where T : class, IEntity
    {
      var query = GetDataStore();
      var persister = new InMemoryPersister(query);
      return new IdentityCreatingRepository<T>(query, persister);
    }

    void CreateDataStoreIfRequired()
    {
      lock(syncRoot)
      {
        if(dataStore == null)
          dataStore = new InMemoryQuery();
      }
    }

    #endregion

    #region constructor

    InMemoryDatabase()
    {
      syncRoot = new object();
    }

    #endregion

    #region singleton

    static readonly InMemoryDatabase instance;

    static InMemoryDatabase()
    {
      instance = new InMemoryDatabase();
    }

    public static InMemoryDatabase Current => instance;

    #endregion
  }
}
