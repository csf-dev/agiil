using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CSF.Reflection;
using CSF.Specifications;

namespace Agiil.ObjectMaps
{
    public class ProfileTypesProvider : IGetsTypes
    {
        readonly IGetsTypes exportedTypesProvider;

        public IReadOnlyCollection<Type> GetTypes()
        {
            return exportedTypesProvider.GetTypes()
                .Where(GetProfilesSpec())
                .ToList();
        }

        ISpecificationExpression<Type> GetProfilesSpec()
        {
            return new IsConcreteClassSpecification()
                .And(new DerivesFromSpecification(typeof(Profile)));
        }

        public ProfileTypesProvider()
        {
            exportedTypesProvider = new ExportedMappingTypesProvider();
        }
    }
}
