using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class DescriptionContainsText : SpecificationExpression<Ticket>
  {
    readonly string text;

    public override Expression<Func<Ticket, bool>> GetExpression()
      => ticket => ticket.Description != null && ticket.Description.Contains(text);

    public DescriptionContainsText(string text)
    {
      if(text == null)
        throw new ArgumentNullException(nameof(text));
      this.text = text;
    }
  }
}
