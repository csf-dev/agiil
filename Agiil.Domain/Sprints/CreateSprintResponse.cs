using System;
namespace Agiil.Domain.Sprints
{
  public class CreateSprintResponse : IIndictesSuccess
  {
    public bool ProjectDoesNotExist { get; set; }

    public bool NameIsInvalid { get; set; }

    public bool EndDateMustNotBeBeforeStartDate { get; set; }

    public bool IsSuccess
      => !(ProjectDoesNotExist || NameIsInvalid || EndDateMustNotBeBeforeStartDate);

    public Sprint Sprint { get; set; }
  }
}
