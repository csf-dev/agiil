using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class TitleContainsText : SpecificationExpression<Ticket>
  {
    readonly string text;

    public override Expression<Func<Ticket, bool>> GetExpression()
    => ticket => ticket.Title != null && ticket.Title.Contains(text);

    public TitleContainsText(string text)
    {
      if(text == null)
        throw new ArgumentNullException(nameof(text));
      this.text = text;
    }
  }
}
