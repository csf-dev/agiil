using System;
using System.Reflection;
using Autofac;
using SpecFlow.Autofac;
using System.Linq;
using TechTalk.SpecFlow;
using Agiil.BDD.Impl;
using Agiil.Tests.Common;

namespace Agiil.BDD
{
  public class BddDependencies
  {
    static readonly IAutofacContainerBuilderFactory autofacContainerBuilderFactory;

    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
      return autofacContainerBuilderFactory.GetContainerBuilder();
    }

    static BddDependencies()
    {
      autofacContainerBuilderFactory = new BddContainerBuilderFactory();
    }
  }
}
