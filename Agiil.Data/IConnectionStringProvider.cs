using System;
using System.Configuration;

namespace Agiil.Data
{
  public interface IConnectionStringProvider
  {
    string GetConnectionString();

    ConnectionStringSettings GetConnectionStringSettings();
  }
}
