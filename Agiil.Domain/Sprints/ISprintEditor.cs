using System;
namespace Agiil.Domain.Sprints
{
  public interface ISprintEditor
  {
    EditSprintResponse Edit(EditSprintRequest request);
  }
}
