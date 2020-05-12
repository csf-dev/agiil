using System;
using AutoMapper;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.ObjectMaps.Resolvers
{
  public class CreateIdentityResolver<TEntity>
    : IMemberValueResolver<object, object, long, IIdentity<TEntity>> where TEntity : IEntity
  {
    public IIdentity<TEntity> Resolve(object source,
                                      object destination,
                                      long sourceMember,
                                      IIdentity<TEntity> destMember, ResolutionContext context)
    {
      return Identity.Create<TEntity>(sourceMember);
    }
  }
}
