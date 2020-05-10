using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasSprint : ISpecificationExpression<Ticket>
  {
    readonly string[] sprintNames;

    public IReadOnlyList<string> SprintNames => sprintNames;

    public Expression<Func<Ticket, bool>> GetExpression()
      => ticket => ticket.Sprint != null && sprintNames.Contains(ticket.Sprint.Name);

    public HasSprint(string sprintName) : this(new [] {sprintName}) {}

    public HasSprint(params string[] sprintNames) : this((IEnumerable<string>) sprintNames) {}

    public HasSprint(IEnumerable<string> sprintName)
    {
      if(sprintName == null)
        throw new ArgumentNullException(nameof(sprintName));

      this.sprintNames = sprintName.ToArray();
    }
  }
}
