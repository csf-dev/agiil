using System.Reflection;
using Autofac;

namespace Agiil.Bootstrap
{
    public class BulkRegisterAllDomainLogicTypesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetAllDomainLogicAssemblies())
                .AsSelf()
                .AsImplementedInterfaces()
                .PreserveExistingDefaults();
        }

        Assembly[] GetAllDomainLogicAssemblies()
        {
            return new[] {
                typeof(Agiil.Auth.AuthenticationImplementationAssemblyMarker).Assembly,
                typeof(Agiil.Auth.AuthenticationAssemblyMarker).Assembly,
                typeof(Agiil.Data.IDataAssemblyMarker).Assembly,
                typeof(Domain.DomainImplAssemblyMarker).Assembly,
                typeof(Domain.DomainAssemblyMarker).Assembly,
                typeof(Agiil.ObjectMaps.IMapperConfigurationFactory).Assembly,
                typeof(Agiil.QueryLanguage.Antlr.AntlrQueryLanguageAssemblyMarker).Assembly,
                typeof(Agiil.QueryLanguage.QueryLanguageImplAssemblyMarker).Assembly,
                typeof(Web.Rendering.MarkdownRenderer).Assembly,
                typeof(Web.Rendering.IRendersMarkdownToHtml).Assembly,
            };
        }
    }
}
