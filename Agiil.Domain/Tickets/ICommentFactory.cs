using System;
using Agiil.Domain.Auth;

namespace Agiil.Domain.Tickets
{
  public interface ICommentFactory
  {
    Comment Create(string body);
  }
}
