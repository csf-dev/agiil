using System;
using CSF.Entities;
using CSF;

namespace Agiil.Domain.Tickets
{
  public abstract class Relationship : Entity<long>
  {
    readonly RelationshipType type;
    RelationshipBehaviour behaviour;

    public virtual string PrimarySummary { get; set; }

    /// <summary>
    /// A discriminator value which indicates the type of relationship.
    /// </summary>
    /// <value>The type.</value>
    public virtual RelationshipType Type => type;

    public abstract void Accept(IVisitsRelationship visitor);

    public virtual RelationshipBehaviour Behaviour
    {
      get => behaviour;
      protected set => behaviour = value;
    }

    protected Relationship()
    {
      behaviour = new RelationshipBehaviour();
    }

    protected Relationship(RelationshipType type) : this()
    {
      type.RequireDefinedValue(nameof(type));

      this.type = type;
    }
  }
}
