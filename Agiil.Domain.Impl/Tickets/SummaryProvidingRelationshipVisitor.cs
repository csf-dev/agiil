using System;
using CSF;

namespace Agiil.Domain.Tickets
{
  public class SummaryProvidingRelationshipVisitor : IVisitsRelationship
  {
    string summary;
    readonly RelationshipParticipant desiredRelationship;

    public void Visit(DirectionalRelationship relationship)
    {
      switch(desiredRelationship)
      {
      case RelationshipParticipant.Primary:
        summary = relationship?.PrimarySummary;
        break;

      case RelationshipParticipant.Secondary:
        summary = relationship?.SecondarySummary;
        break;

      default:
        summary = null;
        break;
      }
    }

    public void Visit(NonDirectionalRelationship relationship)
    {
      summary = relationship?.PrimarySummary;
    }

    public string GetSummary() => summary;

    public SummaryProvidingRelationshipVisitor(RelationshipParticipant desiredRelationship)
    {
      desiredRelationship.RequireDefinedValue(nameof(desiredRelationship));
      this.desiredRelationship = desiredRelationship;
    }
  }
}
