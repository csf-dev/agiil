using System;
using AutoMapper;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.ObjectMaps.Resolvers
{
  public class GetEntityByIdentityResolver<TEntity> : IMemberValueResolver<object, object, IIdentity<TEntity>, TEntity>
    where TEntity : class,IEntity
  {
    readonly IEntityData repo;

    public TEntity Resolve(object source,
                           object destination,
                           IIdentity<TEntity> sourceMember,
                           TEntity destMember,
                           ResolutionContext context)
    {
      if(ReferenceEquals(sourceMember, null))
        return null;

      return repo.Get(sourceMember);
    }

    public GetEntityByIdentityResolver(IEntityData repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
