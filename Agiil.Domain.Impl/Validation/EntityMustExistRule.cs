using System;
using CSF.ORM;
using CSF.Entities;
using CSF.Validation.Rules;

namespace Agiil.Domain.Validation
{
  public class EntityMustExistRule<TEntity> : ValueRule<IIdentity<TEntity>> where TEntity : class,IEntity
  {
    readonly IEntityData repository;

    protected override RuleOutcome GetValueOutcome(IIdentity<TEntity> value)
    {
      if(ReferenceEquals(value, null))
        return Success;

      var entity = repository.Get(value);

      if(ReferenceEquals(entity, null))
        return Failure;

      return Success;
    }

    public EntityMustExistRule(IEntityData repository)
    {
      if(repository == null)
        throw new ArgumentNullException(nameof(repository));
      this.repository = repository;
    }
  }
}
