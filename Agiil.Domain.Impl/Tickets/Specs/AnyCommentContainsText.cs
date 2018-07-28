﻿using System;
using System.Linq;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class AnyCommentContainsText : SpecificationExpression<Ticket>
  {
    readonly string text;

    public override Expression<Func<Ticket, bool>> GetExpression()
    => ticket => ticket.Comments.Any(comment => comment.Body.Contains(text));

    public AnyCommentContainsText(string text)
    {
      if(text == null)
        throw new ArgumentNullException(nameof(text));
      this.text = text;
    }
  }
}
