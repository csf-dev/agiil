using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class QueryLanguageImplModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      BulkRegistrationHelper.Default.RegisterAll<Agiil.QueryLanguage.QueryLanguageImplAssemblyMarker>(builder);
		}
	}
}
