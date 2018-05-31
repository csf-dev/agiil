using System;
using NHibernate.Cfg.MappingSchema;

namespace Agiil.Data.MappingProviders
{
  public interface IGetsHbmMapping
  {
    string Name { get; }

    HbmMapping GetHbmMapping();
  }
}
