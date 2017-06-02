using System;
using AutoMapper;

namespace Agiil.ObjectMaps
{
  public interface IMapperConfigurationFactory
  {
    MapperConfiguration GetConfiguration();
  }
}
