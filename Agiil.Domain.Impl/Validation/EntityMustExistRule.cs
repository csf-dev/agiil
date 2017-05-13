using System;
using CSF.Data.Entities;
using CSF.Entities;
using CSF.Validation.Rules;
using System.Linq;
using CSF.Data.NHibernate;

namespace Agiil.Domain.Validation
{
  public class EntityMustExistRule<TEntity> : ValueRule<IIdentity<TEntity>> where TEntity : class,IEntity
  {
    readonly IRepository<TEntity> repository;

    protected override RuleOutcome GetValueOutcome(IIdentity<TEntity> value)
    {
      if(ReferenceEquals(value, null))
        return Failure;

      var entity = repository.Get(value);

      if(ReferenceEquals(entity, null))
        return Failure;

      return Success;
    }

    public EntityMustExistRule(IRepository<TEntity> repository)
    {
      if(repository == null)
        throw new ArgumentNullException(nameof(repository));
      this.repository = repository;
    }
  }
}
