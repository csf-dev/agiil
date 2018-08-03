using System;
using CSF.Entities;
using CSF;

namespace Agiil.Domain.Tickets
{
  public abstract class Relationship : Entity<long>
  {
    RelationshipType type;

    public virtual string PrimarySummary { get; set; }

    /// <summary>
    /// A discriminator value which indicates the type of relationship.
    /// </summary>
    /// <value>The type.</value>
    public virtual RelationshipType Type => type;

    [Obsolete("Do not use this constructor, it exists only so that NHibernate may proxy this entity")]
    protected Relationship() {}

    protected Relationship(RelationshipType type)
    {
      type.RequireDefinedValue(nameof(type));

      this.type = type;
    }
  }
}
