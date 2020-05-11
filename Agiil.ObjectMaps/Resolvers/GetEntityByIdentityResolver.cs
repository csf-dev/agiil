using System;
using AutoMapper;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.ObjectMaps.Resolvers
{
    public class GetEntityByIdentityResolver<TEntity> : IMemberValueResolver<object, object, IIdentity<TEntity>, TEntity>
      where TEntity : class, IEntity
    {
        readonly IEntityData repo;

        public TEntity Resolve(object source,
                               object destination,
                               IIdentity<TEntity> sourceMember,
                               TEntity destMember,
                               ResolutionContext context)
        {
            return (sourceMember != null) ? repo.Get(sourceMember) : null;
        }

        public GetEntityByIdentityResolver(IEntityData repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
    }
}
