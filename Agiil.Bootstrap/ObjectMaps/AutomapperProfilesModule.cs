using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Agiil.ObjectMaps;
using Autofac;
using AutoMapper;

namespace Agiil.Bootstrap.ObjectMaps
{
  public class AutomapperProfilesModule : Autofac.Module
  {
    readonly IProfileTypesProvider profileTypeProvider;

    protected override void Load(ContainerBuilder builder)
    {
      if(profileTypeProvider == null)
        return;
      
      var allProfileTypes = profileTypeProvider.GetAllProfileTypes();
      foreach(var type in allProfileTypes)
      {
        builder
          .RegisterType(type)
          .As<Profile>();
      }
    }

    public AutomapperProfilesModule() {}

    public AutomapperProfilesModule(IProfileTypesProvider profileTypeProvider)
    {
      if(profileTypeProvider == null)
        throw new ArgumentNullException(nameof(profileTypeProvider));
      
      this.profileTypeProvider = profileTypeProvider;
    }
  }
}
