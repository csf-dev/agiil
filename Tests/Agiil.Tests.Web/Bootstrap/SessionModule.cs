using System;
using Autofac;
using Moq;

namespace Agiil.Tests.Web.Bootstrap
{
    public class SessionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<Agiil.Tests.Bootstrap.SessionModule>();
        }
    }
}
