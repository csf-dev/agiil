using System;
using System.Collections.Generic;
using System.Security;
using System.Web.Mvc;
using Autofac.Features.Metadata;
using System.Linq;
using Autofac.Integration.Mvc;

namespace Agiil.Web.ModelBinders
{
  public class AutofacMvcModelBinderProviderWithOpenGenericSupport : AutofacModelBinderProvider, IModelBinderProvider
  {
    const string MetadataKey = "SupportedModelTypes";

    [SecurityCritical]
    public IModelBinder GetBinderWithOpenGenericSupport(Type modelType)
    {
      if(!modelType.IsGenericType)
      {
        return GetBinder(modelType);
      }

      var binder = GetBinder(modelType);
      if(binder != null)
        return binder;

      return GetOpenGenericBinder(modelType);
    }

    protected IModelBinder GetOpenGenericBinder(Type modelType)
    {
      var allBinders = DependencyResolver
        .Current
        .GetServices<Meta<Lazy<IModelBinder>>>();

      if(!modelType.IsGenericType)
        throw new InvalidOperationException($"The type {modelType.FullName} must be an open generic type.");

      var meta = (from binder in allBinders
                  where binder.Metadata.ContainsKey(MetadataKey)
                  let types = (List<Type>) binder.Metadata[MetadataKey]
                  where types != null
                  let openGenericModelType = modelType.GetGenericTypeDefinition()
                  from type in types
                  where
                    type.IsGenericTypeDefinition
                    && openGenericModelType == type
                  select binder)
        .FirstOrDefault();

        if (meta == null) {
          return null;
        }

        return meta.Value.Value;
    }

    IModelBinder IModelBinderProvider.GetBinder(Type modelType)
    {
      return GetBinderWithOpenGenericSupport(modelType);
    }
  }
}
