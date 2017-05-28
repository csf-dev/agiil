using System;
namespace Agiil.Tests.Sprints
{
  public interface ISprintQueryController
  {
    bool DoesSprintExist(SprintSearchCriteria criteria = null);

    void AssertThatTicketIsPartOfSprint(string ticketReference, string sprintName);

    void AssertThatTicketIsNotPartOfAnySprint(string ticketReference);
 }
}
