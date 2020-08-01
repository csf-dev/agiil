using System;
using NUnit.Framework;

namespace Agiil.Tests
{
    [SetUpFixture]
    public class GlobalOneTimeSetupForAllTests
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
