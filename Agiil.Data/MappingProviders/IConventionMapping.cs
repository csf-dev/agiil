using System;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.MappingProviders
{
  public interface IConventionMapping
  {
    void ApplyMapping(ConventionModelMapper mapper);
  }
}
