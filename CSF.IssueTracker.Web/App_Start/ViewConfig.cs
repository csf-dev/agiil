using System;
using System.Web.Mvc;

namespace CSF.IssueTracker.Web.App_Start
{
  public static class ViewConfig
  {
    public static void RegisterViewEngines(ViewEngineCollection engines)
    {
      engines.Clear();
      engines.Add(new CSF.Zpt.MVC.ZptViewEngine());
    }
  }
}
