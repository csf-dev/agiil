using System;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Resolvers
{
  public class IdentityValueResolver : IValueResolver<IEntity, object, long>
  {
    public long Resolve(IEntity source) => Resolve(source, null, default(long), null);
    
    public long Resolve(IEntity source, object destination, long destMember, ResolutionContext context)
    {
      if(ReferenceEquals(source, null))
        return default(long);
      
      var hasIdentity = source.HasIdentity;
      if(!hasIdentity)
        return default(long);

      return (long) source.IdentityValue;
    }
  }
}
