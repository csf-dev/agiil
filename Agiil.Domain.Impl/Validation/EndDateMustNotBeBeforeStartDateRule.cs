using System;
using CSF.Validation.Rules;

namespace Agiil.Domain.Validation
{
  public class EndDateMustNotBeBeforeStartDateRule : Rule<IHasStartAndEndDates>
  {
    protected override RuleOutcome GetOutcome(IHasStartAndEndDates validated)
    {
      if(validated == null)
        return Success;

      if(!validated.StartDate.HasValue
         || !validated.EndDate.HasValue)
        return Success;

      if(validated.EndDate.Value < validated.StartDate.Value)
        return Failure;

      return Success;
    }
  }
}
