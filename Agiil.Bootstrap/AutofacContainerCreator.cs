using System;
using Autofac;
using log4net;

namespace Agiil.Bootstrap
{
    public class AutofacContainerCreator : IGetsAutofacContainer
    {
        static readonly ILog logger = LogManager.GetLogger(typeof(AutofacContainerCreator));

        readonly IGetsAutofacContainerBuilder builderProvider;

        public IContainer GetContainer()
        {
            try
            {
                var builder = builderProvider.GetContainerBuilder();
                return builder.Build();
            }
            catch(Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public AutofacContainerCreator(IGetsAutofacContainerBuilder builderProvider)
        {
            this.builderProvider = builderProvider ?? throw new ArgumentNullException(nameof(builderProvider));
        }
    }
}
