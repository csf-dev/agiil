using System;
using CSF.Entities;

namespace Agiil.Domain.Data
{
  public interface IPersister
  {
    void Save<TEntity>(TEntity entity) where TEntity : class,IEntity;

    void Update<TEntity>(TEntity entity) where TEntity : class,IEntity;

    void Delete<TEntity>(TEntity entity) where TEntity : class,IEntity;
  }
}
