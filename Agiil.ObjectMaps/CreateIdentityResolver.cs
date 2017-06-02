using System;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps
{
  public class CreateIdentityResolver<TEntity>
    : IMemberValueResolver<object, object, object, IIdentity<TEntity>> where TEntity : IEntity
  {
    public IIdentity<TEntity> Resolve(object source,
                                      object destination,
                                      object sourceMember,
                                      IIdentity<TEntity> destMember, ResolutionContext context)
    {
      return Identity.Create<TEntity>(sourceMember);
    }
  }
}
