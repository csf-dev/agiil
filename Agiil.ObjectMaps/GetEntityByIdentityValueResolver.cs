using System;
using AutoMapper;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.ObjectMaps
{
  public class GetEntityByIdentityValueResolver<TEntity> : IMemberValueResolver<object, object, long, TEntity>
    where TEntity : class,IEntity
  {
    readonly IRepository<TEntity> repo;

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

    public GetEntityByIdentityValueResolver(IRepository<TEntity> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
