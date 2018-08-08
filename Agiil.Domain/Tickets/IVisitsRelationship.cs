using System;
namespace Agiil.Domain.Tickets
{
  public interface IVisitsRelationship
  {
    void Visit(DirectionalRelationship relationship);

    void Visit(NonDirectionalRelationship relationship);
  }
}
