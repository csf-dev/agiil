using System;
using Agiil.Domain.Data;
using Agiil.Web.Data;

namespace Agiil.Web.Services
{
  public class DatabaseMaintainer
  {
    #region fields

    readonly Func<IInitialDataCreator> dataCreatorFactory;

    #endregion

    #region methods

    public void Reset()
    {
      Clear();
      AddTestData();
    }

    public void Clear()
    {
      InMemoryDatabase.Clear();
    }

    public void AddTestData()
    {
      var dataCreator = dataCreatorFactory();
      dataCreator.Create();
    }

    #endregion

    #region constructor

    public DatabaseMaintainer(Func<IInitialDataCreator> dataCreatorFactory)
    {
      if(dataCreatorFactory == null)
        throw new ArgumentNullException(nameof(dataCreatorFactory));

      this.dataCreatorFactory = dataCreatorFactory;
    }

    #endregion
  }
}
