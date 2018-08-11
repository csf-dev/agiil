using System;
namespace Agiil.Domain.Tickets
{
  public class VisitorBasedRelationshipSummaryProvider : IGetsRelationshipSummary
  {
    readonly Func<RelationshipParticipant, SummaryProvidingRelationshipVisitor> visitorFactory;

    public string GetSummary(Relationship relationship, RelationshipParticipant forParticipant)
    {
      if(relationship == null) return null;

      var visitor = visitorFactory(forParticipant);
      relationship.Accept(visitor);
      return visitor.GetSummary();
    }

    public VisitorBasedRelationshipSummaryProvider(Func<RelationshipParticipant,SummaryProvidingRelationshipVisitor> visitorFactory)
    {
      if(visitorFactory == null)
        throw new ArgumentNullException(nameof(visitorFactory));
      this.visitorFactory = visitorFactory;
    }
  }
}
