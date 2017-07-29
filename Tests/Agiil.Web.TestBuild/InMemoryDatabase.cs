using System;
using Agiil.Tests;
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

    public InMemoryQuery GetDataStore()
    {
      CreateDataStoreIfRequired();
      return dataStore;
    }

    public void Reset()
    {
      dataStore = null;
    }

    public IRepository<T> GetRepository<T>()
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
