using System;
namespace Agiil.Domain.Sprints
{
  public interface ISprintCreator
  {
    CreateSprintResponse Create(CreateSprintRequest request);
  }
}
