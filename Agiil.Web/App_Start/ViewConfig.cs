using System.Web.Mvc;
using CSF.Zpt.MVC;

namespace Agiil.Web.App_Start
{
  public static class ViewConfig
  {
    public static void RegisterViewEngines(ViewEngineCollection engines)
    {
      engines.Clear();
      engines.Add(new ZptViewEngine());
    }
  }
}
