using System;
using System.Collections.Generic;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public interface ICommentQueryController
  {
    bool DoesCommentExist(CommentSearchCriteria criteria = null);

    void VerifyThatCommentsAreListedInOrder(IList<CommentDto> expected);
  }
}
