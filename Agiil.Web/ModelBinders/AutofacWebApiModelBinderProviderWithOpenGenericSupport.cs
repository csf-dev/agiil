using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Autofac.Features.Metadata;
using Autofac.Integration.WebApi;

namespace Agiil.Web.ModelBinders
{
  public class AutofacWebApiModelBinderProviderWithOpenGenericSupport : AutofacWebApiModelBinderProvider
  {
    const string MetadataKey = "SupportedModelTypes";

    public override IModelBinder GetBinder(HttpConfiguration configuration,
                                           Type modelType)
    {
      var baseBinder = base.GetBinder(configuration, modelType);

      if(baseBinder != null)
        return baseBinder;

      if(!modelType.IsGenericType)
        return null;

      var allBinders = configuration
        .DependencyResolver
        .GetServices(typeof(Meta<Lazy<IModelBinder>>))
        .Cast<Meta<Lazy<IModelBinder>>>();

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
  }
}
