using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Agiil.Domain;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Agiil.Web;
using Agiil.Web.Controllers;
using Agiil.Web.Services.Tickets;
using log4net;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Web.Services.Tickets
{
  [TestFixture,Parallelizable,Ignore("Temporarily ignored to see if this is the cause of hanging builds #AG377")]
  public class TicketUriProviderTests
  {
    [Test, AutoMoqData]
    public void GetViewTicketUri_gets_correct_Uri_for_viewing_a_ticket(TicketReference reference)
    {
      var helper = Mock.Of<UrlHelper>();
      var baseUriProvider = Mock.Of<IProvidesApplicationBaseUri>(x => x.GetBaseUri() == new Uri("http://example.com/"));
      var sut = new TicketUriProvider(helper, Mock.Of<ILog>(), baseUriProvider);
      Mock.Get(helper)
          .Setup(x => x.Action(nameof(TicketController.Index), typeof(TicketController).AsControllerName(), It.IsAny<object>()))
          .Returns("/One/Two");
      
      var result = sut.GetViewTicketUri(reference);

      Assert.That(result, Is.EqualTo(new Uri("http://example.com/One/Two")));
    }

    [Test, AutoMoqData]
    public void GetViewTicketUri_gets_correct_Uri_for_editing_a_ticket(TicketReference reference, Uri expected)
    {
      var helper = Mock.Of<UrlHelper>();
      var baseUriProvider = Mock.Of<IProvidesApplicationBaseUri>(x => x.GetBaseUri() == new Uri("http://example.com/"));
      var sut = new TicketUriProvider(helper, Mock.Of<ILog>(), baseUriProvider);
      Mock.Get(helper)
          .Setup(x => x.Action(nameof(TicketController.Edit), typeof(TicketController).AsControllerName(), It.IsAny<object>()))
          .Returns("/One/Two");

      var result = sut.GetEditTicketUri(reference);

      Assert.That(result, Is.EqualTo(new Uri("http://example.com/One/Two")));
    }
  }
}
