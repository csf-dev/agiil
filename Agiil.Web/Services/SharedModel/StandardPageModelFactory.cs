using System;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Services.SharedModel
{
  public class StandardPageModelFactory
  {
    readonly StandardPageModelPopulator populator;

    public T GetModel<T>() where T : StandardPageModel,new()
    {
      var output = new T();
      populator.Populate(output);
      return output;
    }

    public StandardPageModelFactory(StandardPageModelPopulator populator)
    {
      if(populator == null)
        throw new ArgumentNullException(nameof(populator));
      this.populator = populator;
    }
  }
}
