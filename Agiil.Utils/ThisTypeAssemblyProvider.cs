using System;
using System.Reflection;

namespace Agiil
{
  public abstract class ThisTypeAssemblyProvider<TDerived>
    : IGetsAssembly
    where TDerived : ThisTypeAssemblyProvider<TDerived>
  {
    public Assembly Assembly => GetType().Assembly;

    public static IGetsAssembly Instance
    {
      get {
        var thisType = typeof(TDerived);
        return (IGetsAssembly) Activator.CreateInstance(thisType);
      }
    }
  }
}
