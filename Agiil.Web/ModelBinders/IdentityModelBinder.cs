using System;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using CSF.Entities;

namespace Agiil.Web.ModelBinders
{
  [ModelBinderType(typeof(IIdentity<>))]
  public class IdentityModelBinder : IModelBinder
  {
    internal static readonly Type BaseIdentityType = typeof(IIdentity<>);

    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      var name = bindingContext.ModelName;
      var value = bindingContext.ValueProvider.GetValue(name);

      if(ReferenceEquals(value, null))
        return null;
      
      var type = bindingContext.ModelType;

      if(!type.IsGenericType
         || type.GetGenericTypeDefinition() != BaseIdentityType)
      {
        return null;
      }

      var entityType = type.GenericTypeArguments[0];
      var identityType = Identity.GetIdentityType(entityType);

      return Identity.Create(entityType, identityType, value.ConvertTo(identityType));
    }
  }
}
