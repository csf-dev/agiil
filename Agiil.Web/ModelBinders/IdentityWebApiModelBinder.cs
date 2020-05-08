using System;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using CSF.Entities;

namespace Agiil.Web.ModelBinders
{
    public class IdentityWebApiModelBinder : IModelBinder
    {
        internal static readonly Type BaseIdentityType = typeof(IIdentity<>);
        static readonly IParsesIdentity parser = new IdentityParser();

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var value = GetValue(bindingContext);
            var entityType = GetEntityType(bindingContext);
            if(entityType == null)
                return false;

            bindingContext.Model = parser.Parse(entityType, value);
            return true;
        }

        Type GetEntityType(ModelBindingContext bindingContext)
        {
            var type = bindingContext.ModelType;
            if(!type.IsGenericType || type.GetGenericTypeDefinition() != BaseIdentityType)
                return null;

            return type.GenericTypeArguments[0];
        }

        object GetValue(ModelBindingContext bindingContext)
        {
            var name = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(name);

            var rawValue = value.RawValue;
            if(rawValue is string[] stringArray)
                return stringArray[0];
            return rawValue;
        }
    }
}
