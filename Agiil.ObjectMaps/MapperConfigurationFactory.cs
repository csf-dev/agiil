using System;
using System.Collections.Generic;
using AutoMapper;

namespace Agiil.ObjectMaps
{
    public class MapperConfigurationFactory : IMapperConfigurationFactory
    {
        readonly IEnumerable<Profile> allProfiles;

        public virtual MapperConfiguration GetConfiguration() => new MapperConfiguration(Configure);

        protected virtual void Configure(IMapperConfigurationExpression config)
        {
            foreach(var profile in allProfiles)
                config.AddProfile(profile);
        }

        public MapperConfigurationFactory(IEnumerable<Profile> allProfiles)
        {
            this.allProfiles = allProfiles ?? throw new ArgumentNullException(nameof(allProfiles));
        }
    }
}
