using System;
using Agiil.Domain.Data;
using CSF.Entities;
using NHibernate;

namespace Agiil.Data
{
  public class NHibernatePersister : IPersister
  {
    readonly ISession session;

    public void Delete<TEntity>(TEntity entity) where TEntity : class,IEntity
    {
      if(entity == null)
        throw new ArgumentNullException(nameof(entity));

      session.Delete(entity);
    }

    public void Save<TEntity>(TEntity entity) where TEntity : class,IEntity
    {
      if(entity == null)
        throw new ArgumentNullException(nameof(entity));

      session.Save(entity);
    }

    public void Update<TEntity>(TEntity entity) where TEntity : class,IEntity
    {
      if(entity == null)
        throw new ArgumentNullException(nameof(entity));

      session.Update(entity);
    }
  }
}
