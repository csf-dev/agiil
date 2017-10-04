using Agiil.Bootstrap;
using Agiil.Data;
using Autofac;
using NUnit.Framework;

namespace Agiil.Tests.Data
{
  [TestFixture]
  public class SessionFactoryFactoryTests
  {
    [Test]
    public void Configuration_is_valid_nhibernate_configuration()
    {
      var container = CachingDomainContainerFactory.Default.GetContainer();
      using(var scope = container.BeginLifetimeScope())
      {
        // Arrange
        var configurationCreator = scope.Resolve<ISessionFactoryFactory>();

        // Act & assert
        Assert.DoesNotThrow(() => configurationCreator.GetConfiguration());
      }
    }

    [Test]
    public void Configuration_can_build_session_factory()
    {
      var container = CachingDomainContainerFactory.Default.GetContainer();
      using(var scope = container.BeginLifetimeScope())
      {
        // Arrange
        var configurationCreator = scope.Resolve<ISessionFactoryFactory>();
        var configuration = configurationCreator.GetConfiguration();

        // Act & assert
        Assert.DoesNotThrow(() => configuration.BuildSessionFactory());
      }
    }
  }
}
