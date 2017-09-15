using System;
using Agiil.Domain.Data;
using Agiil.Web.Data;

namespace Agiil.Web.Services
{
  public class DatabaseMaintainer
  {
    #region fields

    readonly Func<IInitialDataCreator> dataCreatorFactory;
    readonly InMemoryDataManager dataManager;

    #endregion

    #region methods

    public void Reset()
    {
      Clear();
      AddTestData();
    }

    public void Clear()
    {
      dataManager.Clear();
    }

    public void AddTestData()
    {
      var dataCreator = dataCreatorFactory();
      dataCreator.Create();
    }

    #endregion

    #region constructor

    public DatabaseMaintainer(Func<IInitialDataCreator> dataCreatorFactory,
                              InMemoryDataManager dataManager)
    {
      if(dataManager == null)
        throw new ArgumentNullException(nameof(dataManager));
      if(dataCreatorFactory == null)
        throw new ArgumentNullException(nameof(dataCreatorFactory));

      this.dataCreatorFactory = dataCreatorFactory;
      this.dataManager = dataManager;
    }

    #endregion
  }
}
