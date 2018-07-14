using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that at least one of the ticket's comments must contain the given text, verbatim.
  /// </summary>
  public class CommentTextContainsNode : SearchNode
  {
    public string Text { get; set; }

    public override ISpecificationExpression<Ticket> GetSpecification() => new AnyCommentContainsText(Text);
  }
}
