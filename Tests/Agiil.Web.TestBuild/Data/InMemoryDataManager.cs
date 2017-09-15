using System;
using CSF.Data;

namespace Agiil.Web.Data
{
  public class InMemoryDataManager
  {
    #region fields

    readonly object syncRoot;
    InMemoryQuery data;

    #endregion

    #region methods

    public IQuery CurrentQuery
    {
      get {
        CreateDataStoreIfRequired();
        return data;
      }
    }

    public void Clear()
    {
      lock(syncRoot)
      {
        data = null;
      }
    }

    void CreateDataStoreIfRequired()
    {
      lock(syncRoot)
      {
        if(data == null)
          data = new InMemoryQuery();
      }
    }

    #endregion

    #region constructor

    public InMemoryDataManager()
    {
      syncRoot = new object();
    }

    #endregion
  }
}
