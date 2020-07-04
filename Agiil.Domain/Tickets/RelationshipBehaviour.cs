using System;
namespace Agiil.Domain.Tickets
{
  /// <summary>
  /// Describes the behaviour of a <see cref="Relationship"/>.
  /// </summary>
  [Serializable]
  public class RelationshipBehaviour
  {
    /// <summary>
    /// When <c>true</c>, this relationship will not be allowed to create circular references.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is typically used with parent/child relationships which form a hierarchy.  This behaviour (when
    /// activated) prevents that hierarchy from becoming circular.
    /// </para>
    /// <example>
    /// <para>
    /// In the case of a <see cref="DirectionalRelationship"/>, the direction of the relationship matters as to whether
    /// or not a relationship is considered circular. Let's assume the primary/secondary sides are called parent/child:
    /// </para>
    /// <code>
    /// Relationship: parent = Ticket 1, child = Ticket 2
    /// Relationship: parent = Ticket 2, child = Ticket 3
    /// </code>
    /// <para>
    /// A relationship in which Ticket 3 were the parent and Ticket 1 were the child would not be permitted, because
    /// it would create a circular relationship whereby each ticket would be (by following the hierarchy) both the
    /// parent and the child of each other ticket.
    /// </para>
    /// <para>
    /// On the other hand, a new relationship in which Ticket 3 were the child and Ticket 1 the parent would be
    /// permitted.  Whilst Ticket 3 would be the child of Ticket 1 both by virtue of being the child of Ticket 2 and
    /// also the direct child of Ticket 1, the hierarchy may be flattened without any loops.
    /// </para>
    /// </example>
    /// <example>
    /// <para>
    /// In the case of a <see cref="NonDirectionalRelationship"/>, no circular relationships are permitted at all.
    /// Let's assume the relationship is called "associated with":
    /// </para>
    /// <code>
    /// Relationship: Ticket 1 associated with Ticket 2
    /// Relationship: Ticket 2 associated with Ticket 3
    /// </code>
    /// <para>
    /// Under this scenario, no new "associated with" relationship may be added between these tickets.  Tickets 1 and 3
    /// cannot be related or else they would create a circular relationship.
    /// </para>
    /// </example>
    /// </remarks>
    /// <value><c>true</c> if circular relationships are prohibited; otherwise, <c>false</c>.</value>
    public virtual bool ProhibitCircularRelationship { get; set; }

    /// <summary>
    /// When true, any given ticket may have a maximum of one 'secondary relationship' of this relationship type.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is often used for directional parent/child relationships, where a ticket may have at most a
    /// single parent.  What is enforced is that a ticket may only be the "child" or at most one other ticket.
    /// </para>
    /// </remarks>
    /// <value><c>true</c> if multiple secondary relationships are prohibited; otherwise, <c>false</c>.</value>
    public virtual bool ProhibitMultipleSecondaryRelationships { get; set; }
  }
}
