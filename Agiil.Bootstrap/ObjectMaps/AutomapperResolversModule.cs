using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.ObjectMaps.Resolvers;
using Autofac;

namespace Agiil.Bootstrap.ObjectMaps
{
  public class AutomapperResolversModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var types = GetCandidateTypes();

      foreach(var type in types)
      {
        if(type.IsGenericTypeDefinition)
        {
          builder.RegisterGeneric(type);
        }
        else
        {
          builder.RegisterType(type);
        }
      }
    }

    IEnumerable<Type> GetCandidateTypes()
    {
      var marker = typeof(IResolversNamespaceMarker);
      var searchNamespace = marker.Namespace;

      return (from type in marker.Assembly.GetExportedTypes()
              where
                type.Namespace.StartsWith(searchNamespace, StringComparison.InvariantCulture)
                && type.IsClass
                && !type.IsAbstract
                && type.IsAssignableTo<string>()
              select type);
    }
  }
}
