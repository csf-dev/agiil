using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Agiil.Web;
using Agiil.Web.Controllers;
using Agiil.Web.Services.Tickets;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Web.Services.Tickets
{
  [TestFixture,Parallelizable]
  public class TicketUriProviderTests
  {
    [Test, AutoMoqData]
    public void GetViewTicketUri_gets_correct_Uri_for_viewing_a_ticket(TicketReference reference, Uri expected)
    {
      var helper = Mock.Of<UrlHelper>();
      var sut = new TicketUriProvider(helper);
      Mock.Get(helper)
          .Setup(x => x.Action(nameof(TicketController.Index), typeof(TicketController).AsControllerName(), reference))
          .Returns(expected.ToString());
      
      var result = sut.GetViewTicketUri(reference);

      Assert.That(result, Is.EqualTo(expected));
    }

    [Test, AutoMoqData]
    public void GetViewTicketUri_gets_correct_Uri_for_editing_a_ticket(TicketReference reference, Uri expected)
    {
      var helper = Mock.Of<UrlHelper>();
      var sut = new TicketUriProvider(helper);
      Mock.Get(helper)
          .Setup(x => x.Action(nameof(TicketController.Edit), typeof(TicketController).AsControllerName(), reference))
          .Returns(expected.ToString());

      var result = sut.GetEditTicketUri(reference);

      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
