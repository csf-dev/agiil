using System.Web.Mvc;
using CSF.Zpt.MVC;

namespace CSF.IssueTracker.Web.App_Start
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
