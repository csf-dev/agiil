using System;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public interface ICommentController
  {
    void Add(AddCommentSpecification comment);

    void Edit(EditCommentSpecification comment);
  }
}
