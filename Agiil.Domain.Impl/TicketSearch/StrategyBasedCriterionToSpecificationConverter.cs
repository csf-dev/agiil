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
    readonly IEnumerable<IStrategyForConvertingCriterionToSpecification> strategies;

    public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
    {
      var strategy = ChooseStrategy(criterion);
      if(strategy == null) return null;
      return strategy.ConvertToSpecification(criterion);
    }

    IConvertsCriterionToSpecification ChooseStrategy(Criterion criterion)
    {
      if(criterion == null) return null;

      return (from strategy in strategies
              let metadata = strategy.GetMetadata()
              where
                metadata != null
                && metadata.CanConvert(criterion)
              select strategy)
        .FirstOrDefault();
    }

    public StrategyBasedCriterionToSpecificationConverter(IEnumerable<IStrategyForConvertingCriterionToSpecification> strategies)
    {
      if(strategies == null)
        throw new ArgumentNullException(nameof(strategies));
      this.strategies = strategies;
    }
  }
}
