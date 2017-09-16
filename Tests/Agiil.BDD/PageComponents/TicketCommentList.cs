using System;
using CSF.Screenplay.Web.Models;

namespace Agiil.BDD.PageComponents
{
  public class TicketCommentList
  {
    public ILocatorBasedTarget CommentList => new CssSelector("ol.comment_list",
                                                              "the list of comments");

    public ILocatorBasedTarget EditCommentLink => new CssSelector("ol.comment_list a.edit_comment",
                                                                  "the edit-comment link");

  }
}
