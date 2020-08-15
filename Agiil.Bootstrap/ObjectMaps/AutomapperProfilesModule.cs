using System.Linq;
using Agiil.ObjectMaps;
using Autofac;
using AutoMapper;

namespace Agiil.Bootstrap.ObjectMaps
{
    public class AutomapperProfilesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var allProfileTypes = new ProfileTypesProvider()
                .GetTypes()
                .ToArray();

            builder.RegisterTypes(allProfileTypes)
                .AsSelf()
                .As<Profile>();
        }
    }
}
