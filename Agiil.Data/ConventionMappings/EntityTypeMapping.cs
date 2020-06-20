using System;
using NHibernate.Mapping.ByCode;
using Agiil.Data.MappingProviders;

namespace Agiil.Data.ConventionMappings
{
    public class EntityTypeMapping : IConventionMapping
    {
        readonly IDbNameFormatter formatter;

        public void ApplyMapping(ConventionModelMapper mapper)
        {
            mapper.IsEntity(IsEntity);

            mapper.BeforeMapClass += (modelInspector, type, classCustomizer) => {
                classCustomizer.Table(formatter.GetTableName(type));
            };
        }

        bool IsEntity(Type type, bool isDeclaredAsEntity)
        {
            if(!type.IsClass) return false;
            if(!AgiilMappingProvider.BaseEntityType.IsAssignableFrom(type)) return false;
            if(AgiilMappingProvider.IsEntityBaseType(type)) return false;
            if(type == typeof(Domain.App.AgiilApp)) return false;

            return true;
        }

        public EntityTypeMapping(IDbNameFormatter formatter)
        {
            this.formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }
    }
}
