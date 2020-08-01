using Agiil.Domain.Labels;
using Autofac;

namespace Agiil.Bootstrap.Labels
{
    public class LabelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(GetLabelProvider);

            // There are a few implementations but this one is registered for the interface
            builder.RegisterType<LabelSearcher>().As<ISearchesForLabels>();
        }

        IGetsLabels GetLabelProvider(IComponentContext ctx)
        {
            var existingLabelProvider = ctx.Resolve<ExistingLabelProvider>();
            var newLabelProvider = ctx.Resolve<NewLabelProvider>();
            var nameParser = ctx.Resolve<IParsesLabelNames>();
            return new ExistingAndNewLabelProvider(existingLabelProvider, newLabelProvider, nameParser);
        }
    }
}
