using System;
namespace Agiil.Web.Models.Sprints
{
  public class EditSprintResponse
  {
    public bool IdIsInvalid { get; set; }

    public bool NameIsInvalid { get; set; }

    public bool EndDateMustNotBeBeforeStartDate { get; set; }

    public bool IsSuccess { get; set; }

    public bool IsFailure => !IsSuccess;
  }
}
