using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
namespace Agiil.ObjectMaps
{
  public class MapperConfigurationFactory : IMapperConfigurationFactory
  {
    readonly IEnumerable<Profile> allProfiles;

    public virtual MapperConfiguration GetConfiguration()
    {
      return new MapperConfiguration(Configure);
    }

    protected virtual void Configure(IMapperConfigurationExpression config)
    {
      foreach(var profile in allProfiles)
      {
        config.AddProfile(profile);
      }
    }

    public MapperConfigurationFactory(IEnumerable<Profile> allProfiles)
    {
      if(allProfiles == null)
        throw new ArgumentNullException(nameof(allProfiles));
      this.allProfiles = allProfiles;
    }
  }
}
