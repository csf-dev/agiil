using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using Agiil.Web.ModelBinders;
using CSF.Entities;

namespace Agiil.Web.App_Start
{
  public class WebApiModelBindingRules
  {
    public void Apply(HttpConfiguration config)
    {
      ApplyParameterBinding(config);
      ApplyJsonSerializationBinding(config);
    }

    void ApplyParameterBinding(HttpConfiguration config)
    {
      config.ParameterBindingRules.Add(param => {
        var isIdentityType = IsIdentityType(param.ParameterType);
        if(isIdentityType) return param.BindWithModelBinding();
        return null;
      });
    }

    void ApplyJsonSerializationBinding(HttpConfiguration config)
    {
      var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
      jsonSettings.Converters.Add(new IdentityJsonConverter());
    }

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
