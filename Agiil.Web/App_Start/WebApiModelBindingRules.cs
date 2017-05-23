using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.App_Start
{
  public class WebApiModelBindingRules
  {
    public void Apply(HttpConfiguration config)
    {
      // TODO: It might be possible to use the single-parameter overload of the below method to do open-generic registration
      config
        .ParameterBindingRules
        .Add(typeof(IIdentity<Ticket>), p => p.BindWithModelBinding());
    }
  }
}
