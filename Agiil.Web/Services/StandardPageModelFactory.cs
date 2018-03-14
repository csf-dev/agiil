using System;
using Agiil.Web.Models;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Services
{
  public class StandardPageModelFactory
  {
    readonly LoginStateModelPopulator populator;

    public T GetModel<T>() where T : PageModel,new()
    {
      var output = new T();
      populator.Populate(output);
      return output;
    }

    public StandardPageModelFactory(LoginStateModelPopulator populator)
    {
      if(populator == null)
        throw new ArgumentNullException(nameof(populator));
      this.populator = populator;
    }
  }
}
