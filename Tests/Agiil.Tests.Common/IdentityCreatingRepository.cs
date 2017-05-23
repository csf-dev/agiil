using System;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Tests
{
  public class IdentityCreatingRepository<T> : GenericRepository<T>,IRepository<T> where T : class,IEntity
  {
    public new void Add(T entity)
    {
      GenerateIdentityIfNeeded(entity);
      base.Add(entity);
    }

    public new void Update(T entity)
    {
      GenerateIdentityIfNeeded(entity);
      base.Update(entity);
    }

    public new void Remove(T entity)
    {
      GenerateIdentityIfNeeded(entity);
      base.Remove(entity);
    }

    void IRepository<T>.Add(T entity)
    {
      this.Add(entity);
    }

    void IRepository<T>.Update(T entity)
    {
      this.Update(entity);
    }

    void IRepository<T>.Remove(T entity)
    {
      this.Remove(entity);
    }

    void GenerateIdentityIfNeeded(T entity)
    {
      if(ReferenceEquals(entity, null))
        return;
      
      if(!entity.HasIdentity)
      {
        entity.GenerateIdentity();
      }
    }

    public IdentityCreatingRepository(IQuery query, IPersister persister) : base(query, persister) {}
  }
}
