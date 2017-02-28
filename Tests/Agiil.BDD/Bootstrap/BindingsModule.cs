using System;
using System.Linq;
using System.Reflection;
using Autofac;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bootstrap
{
  public class BindingsModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var bindingTypes = Assembly.GetExecutingAssembly()
        .GetExportedTypes()
        .Where(x => Attribute.IsDefined(x, typeof(BindingAttribute)))
        .ToArray();

      builder.RegisterTypes(bindingTypes).AsSelf().InstancePerLifetimeScope();
    }
  }
}
