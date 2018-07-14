using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's title must contain the given text, verbatim.
  /// </summary>
  public class TitleTextContainsNode : SearchNode, IGetsTicketSpecification
  {
    public string Text { get; set; }

    public ISpecificationExpression<Ticket> GetSpecification() => new TitleContainsText(Text);
  }
}
