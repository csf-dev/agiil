using System;
using Agiil.Domain.Auth;

namespace Agiil.Bootstrap.Auth
{
  public class DomainAuthModule : NamespaceModule
  {
    protected override string Namespace => typeof(User).Namespace;
  }
}
