using System;
using Agiil.Web.Models.Sprints;

namespace Agiil.Tests.Sprints
{
  public interface ISprintEditingController
  {
    void Edit(EditSprintSpecification spec);
  }
}
