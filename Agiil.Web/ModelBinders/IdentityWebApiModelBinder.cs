﻿using System;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using CSF.Entities;

namespace Agiil.Web.ModelBinders
{
  public class IdentityWebApiModelBinder : IModelBinder
  {
    public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
    {
      var name = bindingContext.ModelName;
      var value = bindingContext.ValueProvider.GetValue(name);

      if(ReferenceEquals(value, null))
        return false;

      var type = bindingContext.ModelType;

      if(!type.IsGenericType
         || type.GetGenericTypeDefinition() != IdentityModelBinder.BaseIdentityType)
      {
        return false;
      }

      var entityType = type.GenericTypeArguments[0];
      var identityType = Identity.GetIdentityType(entityType);

      bindingContext.Model = Identity.Create(entityType, identityType, value.ConvertTo(identityType));
      return true;
    }
  }
}