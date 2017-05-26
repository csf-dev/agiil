using System;
using Agiil.Web.Models.Sprints;

namespace Agiil.Tests.Sprints
{
  public interface ISprintCreationController
  {
    void Create(NewSprintSpecification spec);
  }
}
