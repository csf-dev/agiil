using System;
namespace Agiil.Domain.Tickets
{
  public interface IGetsRelationshipSummary
  {
    string GetSummary(Relationship relationship, RelationshipParticipant forParticipant);
  }
}
