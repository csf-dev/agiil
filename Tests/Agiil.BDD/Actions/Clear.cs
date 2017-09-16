using System;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Actions;
using CSF.Screenplay.Web.Models;

namespace Agiil.BDD.Actions
{
  public class Clear
  {
    public static IPerformable TheContentsOf(ITarget target)
    {
      return new TargettedAction(target, new ClearTheContents());
    }
  }
}
