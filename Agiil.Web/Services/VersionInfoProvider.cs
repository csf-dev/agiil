using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Domain;

namespace Agiil.Web.Services
{
  public class VersionInfoProvider : IProvidesVersionInformation
  {
    public virtual IReadOnlyCollection<ComponentVersionInfo> GetComponentVersions()
    {
      return new [] {
        GetVersionFromAssemblyWhichContains<Global>(),
        GetVersionFromAssemblyWhichContains<IDomainAssemblyMarker>(),
      };
    }

    public virtual string GetHumanReadableProductVersion()
    {
      var assembly = Assembly.GetExecutingAssembly();
      return GetInformationalVersion(assembly) ?? GetAssemblyVersion(assembly);
    }

    protected ComponentVersionInfo GetVersionFromAssemblyWhichContains<T>()
    {
      var assemblyName = typeof(T).Assembly.GetName();
      return new ComponentVersionInfo {
        ComponentName = assemblyName.Name,
        Version = assemblyName.Version.ToString(),
      };
    }

    protected string GetInformationalVersion(Assembly assembly)
    {
      return assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
    }

    protected string GetAssemblyVersion(Assembly assembly)
    {
      return assembly?.GetName().Version?.ToString();
    }
  }
}
