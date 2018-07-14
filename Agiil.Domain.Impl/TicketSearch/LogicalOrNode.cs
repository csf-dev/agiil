using System;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// Indicates that ANY of the <see cref="IHasChildNodes.Children"/> of the current node must be true in order to
  /// consider this criterion satisfied.
  /// </summary>
  public class LogicalOrNode : SearchBranch
  {
    public override ISpecificationExpression<Ticket> GetSpecification()
    {
      ISpecificationExpression<Ticket> output = null;

      foreach(var child in Children)
      {
        var spec = child?.GetSpecification();
        if(spec == null) continue;

        output = (output == null)? spec : output.Or(spec);
      }

      return output;
    }
  }
}
