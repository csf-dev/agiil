using System;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public interface IEditTicketController
  {
    void Edit(EditTicketTitleAndDescriptionSpecification request);

    void AddToSprint(string ticketReference, string sprintName);
  }
}
