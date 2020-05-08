using System;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using CSF.Entities;
using log4net;

namespace Agiil.Web.ModelBinders
{
    [ModelBinderType(typeof(IIdentity<>))]
    public class IdentityModelBinder : IModelBinder
    {
        internal static readonly Type BaseIdentityType = typeof(IIdentity<>);
        static readonly IParsesIdentity parser = new IdentityParser();
        private readonly ILog logger;

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = GetValue(bindingContext);
            var entityType = GetEntityType(bindingContext);

            logger.Debug($"{bindingContext.ModelName}: Got entity type {entityType.Name} & ID value {value?.ToString() ?? "<null>"}");

            return parser.Parse(entityType, value);
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

        public IdentityModelBinder(ILog logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
