using System;
﻿using Autofac;
using SpecFlow.Autofac;
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
