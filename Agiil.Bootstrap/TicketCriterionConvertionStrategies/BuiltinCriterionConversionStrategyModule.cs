using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain;
using Agiil.Domain.TicketSearch;
using Autofac;

namespace Agiil.Bootstrap.TicketCriterionConvertionStrategies
{
  public class BuiltinCriterionConversionStrategyModule : Module
  {
    const string MetadataMethodName = "GetMetadata";

		protected override void Load(ContainerBuilder builder)
		{
      
      var strategyTypes = GetCandidateTypes()
        .Where(IsStrategyClass)
        .ToArray();

      builder.RegisterTypes(strategyTypes).AsImplementedInterfaces();
		}

    bool IsStrategyClass(Type type)
    {
      return (typeof(IStrategyForConvertingCriterionToSpecification).IsAssignableFrom(type)
              && type.IsClass
              && !type.IsAbstract);
                                                                                   
    }

    IEnumerable<Type> GetCandidateTypes()
    {
      return typeof(IDomainImplementationAssemblyMarker)
        .Assembly
        .GetExportedTypes();
    }
	}
}
