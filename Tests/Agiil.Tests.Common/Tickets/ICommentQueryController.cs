using System;
using System.Collections.Generic;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public interface ICommentQueryController
  {
    bool DoesCommentExist(CommentSearchCriteria criteria = null);

    void VerifyThatCommentsAreListedInOrder(IList<CommentDto> expected);
  }
}
