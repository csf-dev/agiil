using System;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data
{
  public interface IMapping
  {
    void ApplyMapping(ConventionModelMapper mapper);
  }
}
