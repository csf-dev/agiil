using System;
using NHibernate.Mapping.ByCode;
using Agiil.Data.MappingProviders;

namespace Agiil.Data.ConventionMappings
{
  public class ManyToOneMapping : IConventionMapping
  {
    readonly IDbNameFormatter formatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.BeforeMapManyToOne += (modelInspector, member, propertyCustomizer) => {
        var parentType = member.LocalMember.GetPropertyOrFieldType();
        var childType = member.LocalMember.ReflectedType;

        propertyCustomizer.Column(formatter.GetIdentityColumnName(parentType));
        propertyCustomizer.ForeignKey(formatter.GetForeignKeyConstraintName(parentType, childType));
        propertyCustomizer.Index(formatter.GetIndexName(childType, parentType));
        propertyCustomizer.Cascade(Cascade.Persist);
      };
    }

    public ManyToOneMapping(IDbNameFormatter formatter)
    {
      if(formatter == null)
        throw new ArgumentNullException(nameof(formatter));
      this.formatter = formatter;
    }
  }
}
