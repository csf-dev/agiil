using System;
using NHibernate;
using NHibernate.Cfg;

namespace Agiil.Data
{
  public interface ISessionFactoryFactory
  {
    ISessionFactory GetSessionFactory();

    Configuration GetConfiguration();
  }
}
