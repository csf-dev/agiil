using System;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public interface IEditTicketController
  {
    void Edit(EditTicketTitleAndDescriptionSpecification request);
  }
}
