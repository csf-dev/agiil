using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public interface IEditTicketTitleAndDescriptionValidatorFactory
  {
    IValidator GetValidator();
  }
}
