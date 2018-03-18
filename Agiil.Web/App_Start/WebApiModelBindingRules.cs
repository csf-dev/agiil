using System;
using System.Linq;
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

    public static bool IsIdentityType(Type type) => GetEntityType(type) != null;

    public static Type GetEntityType(Type identityType)
    {
      if(identityType == null) return null;

      var implementedInterfaces = identityType
        .GetInterfaces()
        .Union(new [] { identityType });

      var genericIdentityInterface = (from iface in implementedInterfaces
                                      where
                                        iface.IsInterface
                                        && iface.IsGenericType
                                        && iface.GetGenericTypeDefinition() == typeof(IIdentity<>)
                                      select iface)
        .SingleOrDefault();

      if(genericIdentityInterface == null) return null;

      return genericIdentityInterface.GenericTypeArguments[0];
    }
  }
}
