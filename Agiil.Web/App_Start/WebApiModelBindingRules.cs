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
      // TODO: #AG29 - Investigate using the single-parameter overload (open-generic registration?)
      config
        .ParameterBindingRules
        .Add(typeof(IIdentity<Ticket>), p => p.BindWithModelBinding());
    }
  }
}
