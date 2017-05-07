using System;
using System.Reflection;
using NHibernate.Id;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.Mappings
{
  public class IdentityMapping : IMapping
  {
    internal const string IdentityPropertyName = "IdentityValue";
    const BindingFlags IdentityBindingFlags = BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.BeforeMapClass += (modelInspector, type, classCustomizer) => {
        classCustomizer.Id(type.GetProperty(IdentityPropertyName,IdentityBindingFlags),
                           m => {
          m.Generator(new NativeGeneratorDef());
          m.Type(new NHibernate.Type.Int64Type());
          m.Column("id");
        });
      };
    }
  }
}
