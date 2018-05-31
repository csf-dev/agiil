using System;
namespace Agiil.Domain
{
  /// <summary>
  /// An attribute which indicates that the given property is many-to-many
  /// relationship between two entity types.
  /// </summary>
  public class ManyToManyAttribute : Attribute
  {
    /// <summary>
    /// Gets a value which indicates whether or not this is the 'active' side of
    /// the many-to-many relationship.  The active side is 'the more important' side
    /// of the association, and should be the one which has less entries.
    /// </summary>
    /// <value><c>true</c> if the decorated property represents the 'active side'
    /// of the many-to-many relationship; otherwise, <c>false</c>.</value>
    public bool IsActiveSide { get; }

    public ManyToManyAttribute() : this(true) {}

    public ManyToManyAttribute(bool isActiveSide)
    {
      IsActiveSide = isActiveSide;
    }
  }
}
