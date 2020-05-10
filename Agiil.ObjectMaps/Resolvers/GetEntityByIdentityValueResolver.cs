using System;
using AutoMapper;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.ObjectMaps.Resolvers
{
  public class GetEntityByIdentityValueResolver<TEntity> : IMemberValueResolver<object, object, long, TEntity>
    where TEntity : class,IEntity
  {
    readonly IEntityData repo;

    public TEntity Resolve(object source,
                           object destination,
                           long sourceMember,
                           TEntity destMember,
                           ResolutionContext context)
    {
      var identity = Identity.Create<TEntity>(sourceMember);
      if(ReferenceEquals(identity, null))
        return null;

      return repo.Get(identity);
    }

    public GetEntityByIdentityValueResolver(IEntityData repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
