using System;
using System.Collections.Generic;

namespace Agiil.Tests.Tickets
{
  public interface IBulkCommentCreator
  {
    void CreateComments(IEnumerable<BulkCommentSpecification> comments);
  }
}
