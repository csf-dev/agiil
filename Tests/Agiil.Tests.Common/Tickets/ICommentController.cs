using System;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public interface ICommentController
  {
    void Add(AddCommentSpecification comment);

    void Edit(EditCommentSpecification comment);
  }
}
