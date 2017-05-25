using System;
using System.Reflection;
using AutoMapper;
namespace Agiil.ObjectMaps
{
  public class MapperConfigurationFactory
  {
    public virtual MapperConfiguration GetConfiguration()
    {
      return new MapperConfiguration(x => {
        x.AddProfiles(Assembly.GetExecutingAssembly());
      });
    }
  }
}
