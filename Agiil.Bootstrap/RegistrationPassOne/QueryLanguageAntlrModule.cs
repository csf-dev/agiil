using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class QueryLanguageAntlrModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      BulkRegistrationHelper.Default.RegisterAll<Agiil.QueryLanguage.Antlr.AntlrQueryLanguageAssemblyMarker>(builder);
		}
	}
}
