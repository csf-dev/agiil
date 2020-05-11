using System;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Resolvers
{
    public class IdentityValueResolver : IValueResolver<IEntity, object, long>, IMemberValueResolver<object, object, IEntity, long>
    {
        public long Resolve(IEntity source) => Resolve(source, null, default(long), null);

        public long Resolve(IEntity source,
                            object destination,
                            long destMember,
                            ResolutionContext context)
        {
            return (source?.HasIdentity == true)? (long) source.IdentityValue : default(long);
        }

        public long Resolve(object source,
                            object destination,
                            IEntity sourceMember,
                            long destMember,
                            ResolutionContext context)
            => Resolve(sourceMember, destination, destMember, context);
    }
}
