using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain;
using Autofac;
using Autofac.Core;
using log4net;

namespace Agiil.Bootstrap
{
  /// <summary>
  /// Autofac registration module to inject Log4net <code>ILog</code> instances into any components which
  /// are resolved from DI.
  /// </summary>
  /// <remarks>
  /// <para>
  /// This is based on the example shown at https://autofaccn.readthedocs.io/en/latest/examples/log4net.html
  /// although with a little modification for clarity and to resolve the actual log provider from a service.
  /// </para>
  /// </remarks>
  public class Log4NetModule : Module
  {
    #region Module implementation

    protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
                                                          IComponentRegistration registration)
    {
      // Inject logger into component constructors by adding an extra Autofac param.
      registration.Preparing += OnComponentPreparing;

      // Perform property-injection into activated components by setting properties manually.
      // Presently there's no direct requirement for this.  If it becomes a performance drag then this
      // could safely be removed, since we don't use constructor-injection in Agiil.
      registration.Activated += OnComponentActivated;
    }

    protected override void Load(ContainerBuilder builder)
    {
      RegisterLogProvider(builder);
      base.Load(builder);
    }

    #endregion

    void OnComponentActivated(object sender, ActivatedEventArgs<object> e)
    {
      var instanceType = e.Instance.GetType();
      var logProvider = e.Context.Resolve<IGetsLoggerForType>();

      var properties = GetAllPublicSettableLogProperties(instanceType);

      foreach (var propToSet in properties)
        propToSet.SetValue(e.Instance, logProvider.GetLogger(instanceType), null);
    }

    IEnumerable<System.Reflection.PropertyInfo> GetAllPublicSettableLogProperties(Type type)
    {
      return type
        .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
        .Where(p => p.PropertyType == typeof(ILog)
               && p.CanWrite
               && p.GetIndexParameters().Length == 0)
        .ToArray();
    }

    void OnComponentPreparing(object sender, PreparingEventArgs e)
    {
      var logProvider = e.Context.Resolve<IGetsLoggerForType>();

      e.Parameters = e.Parameters.Union(
        new[]
        {
          new ResolvedParameter(
            (p, i) => p.ParameterType == typeof(ILog),
            (p, i) => logProvider.GetLogger(p.Member.DeclaringType)
          ),
        });
    }

    void RegisterLogProvider(ContainerBuilder builder)
    {
      builder.RegisterType<Log4NetLoggerForTypeProvider>();
      builder.RegisterType<CachingLogForTypeDecorator>();

      builder
        .Register(ctx => {
          var baseImpl = (IGetsLoggerForType) ctx.Resolve<Log4NetLoggerForTypeProvider>();
          return ctx.Resolve<CachingLogForTypeDecorator>(TypedParameter.From(baseImpl));
        })
        .As<IGetsLoggerForType>()
        .SingleInstance();
    }
	}
}
