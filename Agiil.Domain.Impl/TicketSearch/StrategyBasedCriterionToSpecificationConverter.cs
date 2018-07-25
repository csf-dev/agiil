using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Agiil.Domain.Tickets;
using System.Linq;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  public class StrategyBasedCriterionToSpecificationConverter : IConvertsCriterionToSpecification
  {
    readonly IEnumerable<Lazy<IStrategyForConvertingCriterionToSpecification, CriterionToSpecificationConversionStrategyMetadata>> strategies;

    public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
    {
      var strategy = ChooseStrategy(criterion);
      if(strategy == null) return null;
      return strategy.ConvertToSpecification(criterion);
    }

    IConvertsCriterionToSpecification ChooseStrategy(Criterion criterion)
    {
      if(criterion == null) return null;
      return strategies.FirstOrDefault(x => x.Metadata.CanConvert(criterion))?.Value;
    }

    public StrategyBasedCriterionToSpecificationConverter(IEnumerable<Lazy<IStrategyForConvertingCriterionToSpecification,CriterionToSpecificationConversionStrategyMetadata>> strategies)
    {
      if(strategies == null)
        throw new ArgumentNullException(nameof(strategies));
      this.strategies = strategies;
    }
  }
}
