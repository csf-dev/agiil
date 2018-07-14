using System;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's description must be similar to the given text, using
  /// natural text relevance matching.
  /// </summary>
  [NaturalTextOrdering]
  public class DescriptionTextSimilarNode : SearchLeaf
  {
    public string Text { get; set; }

    public override ISpecificationExpression<Ticket> GetSpecification()
    {
      // TODO: Write this implementation
      throw new NotImplementedException();
    }
  }
}
