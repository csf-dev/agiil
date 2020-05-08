using Autofac;
using CSF.ORM;
using CSF.ORM.InMemory;
using CSF.ORM.NHibernate;

namespace Agiil.Bootstrap.Data
{
    public class ExternalDataDependenciesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var csfOrmNHibernateAssemblies = new[] {
                typeof(IQuery).Assembly,
                typeof(IEntityData).Assembly,
                typeof(SessionAdapter).Assembly,
                typeof(TransactionAdapter).Assembly,
            };

            builder
                .RegisterAssemblyTypes(csfOrmNHibernateAssemblies)
                .Where(x => !x.Namespace.StartsWith(typeof(DataStore).Namespace, System.StringComparison.InvariantCulture))
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}
