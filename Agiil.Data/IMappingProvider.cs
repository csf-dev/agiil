using System;
using NHibernate.Cfg.MappingSchema;

namespace Agiil.Data
{
  public interface IMappingProvider
  {
    HbmMapping GetHbmMapping();
  }
}
