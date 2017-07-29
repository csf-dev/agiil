using System;
using Autofac;

namespace Agiil.Web.TestBuild
{
  /// <summary>
  /// Service locator type to get the current DI container.
  /// </summary>
  static class ApplicationContainer
  {
    static IContainer currentContainer;

    internal static IContainer Current
    {
      get { return currentContainer; }
      set {
        if(value == null)
          throw new ArgumentNullException(nameof(value));
        if(currentContainer != null)
          throw new InvalidOperationException("There must not be a current container already.");

        currentContainer = value;
      }
    }
  }
}
