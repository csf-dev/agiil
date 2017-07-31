using System;
using CSF.Data;

namespace Agiil.Web.TestBuild.Data
{
  public class InMemoryDatabase
  {
    #region fields

    static readonly object syncRoot;
    static InMemoryQuery dataStore;

    #endregion

    #region methods

    public static InMemoryQuery Current
    {
      get {
        CreateDataStoreIfRequired();
        return dataStore;
      }
    }

    public static void Clear()
    {
      lock(syncRoot)
      {
        dataStore = null;
      }
    }

    static void CreateDataStoreIfRequired()
    {
      lock(syncRoot)
      {
        if(dataStore == null)
          dataStore = new InMemoryQuery();
      }
    }

    #endregion

    #region constructor

    static InMemoryDatabase()
    {
      syncRoot = new object();
    }

    #endregion
  }
}
