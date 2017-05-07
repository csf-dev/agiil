using System;

namespace Agiil.Web.OAuth
{
  /// <summary>
  /// This type is required because the OWIN implementation of OAuth does not kick off either of the ASP.NET MVC or ASP.NET
  /// Web API stacks.  This means that the Autofac HTTP module which sets up the 'per request' lifetime scope is never
  /// executed.  This type is responsible for ensuring that it is done manually.
  /// </summary>
  public interface IOAuthApplicationConnection : IDisposable
  {
    IOAuthAuthorizationChecker GetAuthChecker();
  }
}
