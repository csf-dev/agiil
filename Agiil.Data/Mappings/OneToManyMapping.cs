using System;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.Mappings
{
  public class OneToManyMapping : IMapping
  {
    readonly IDbNameFormatter formatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.BeforeMapSet += (modelInspector, member, propertyCustomizer) => {
        propertyCustomizer.Inverse(true);
        propertyCustomizer.Key(keyMap => {
          var parentType = member.LocalMember.ReflectedType;
          var childType = member.LocalMember.GetPropertyOrFieldType().GetGenericArguments()[0];
          keyMap.Column(formatter.GetIdentityColumnName(parentType));
          keyMap.ForeignKey(formatter.GetForeignKeyConstraintName(parentType, childType));
        });
        propertyCustomizer.Cascade(Cascade.All | Cascade.DeleteOrphans);
      };
    }

    public OneToManyMapping(IDbNameFormatter formatter)
    {
      if(formatter == null)
        throw new ArgumentNullException(nameof(formatter));
      this.formatter = formatter;
    }
  }
}
