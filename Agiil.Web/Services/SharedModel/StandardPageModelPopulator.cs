using System;
using Agiil.Web.Models;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Services.SharedModel
{
  public class StandardPageModelPopulator
  {
    readonly LoginStateReader loginStateReader;

    public void Populate(StandardPageModel model)
    {
      if(model == null)
        throw new ArgumentNullException(nameof(model));

      model.LoginState = loginStateReader.GetLoginState();
    }

    public StandardPageModelPopulator(LoginStateReader loginStateReader)
    {
      if(loginStateReader == null)
        throw new ArgumentNullException(nameof(loginStateReader));
      
      this.loginStateReader = loginStateReader;
    }
  }
}
