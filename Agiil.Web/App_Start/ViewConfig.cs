using System.Web.Mvc;
using CSF.Zpt.MVC;

namespace Agiil.Web.App_Start
{
  public class ViewConfig
  {
    public void RegisterViewEngines(ViewEngineCollection engines)
    {
      engines.Clear();
      engines.Add(new ZptViewEngine());
    }
  }
}
