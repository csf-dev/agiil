using System;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using Agiil.Web.Rendering;
using Agiil.Web.Rendering.Tickets;
using Autofac;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Web.Rendering
{
  [TestFixture,Category( "Integration"),Category("DependencyInjection")]
  public class MarkdownRendererTests
  {
    IContainer container;
    ILifetimeScope diScope;
    IRendersMarkdownToHtml Sut => diScope.Resolve<IRendersMarkdownToHtml>();

    [OneTimeSetUp]
    public void FixtureSetup()
    {
      container = CachingWebAppContainerFactory.Default.GetContainer();
    }

    [SetUp]
    public void Setup()
    {
      diScope = container.BeginLifetimeScope();
    }

    [OneTimeTearDown]
    public void FixtureTeardown()
    {
      if(container != null)
        container.Dispose();
    }

    [TearDown]
    public void Teardown()
    {
      if(diScope != null)
        diScope.Dispose();
    }

    [Test,Description("This is a simple smoke-screen that the markdown renderer is functional, rendering a paragraph with some bold text.")]
    public void GetHtml_should_be_able_to_render_a_paragraph_with_strongly_emphasised_text()
    {
      // Arrange
      var markdown = "This is some **markdown** which I am going to render.";

      // Act
      var result = Sut.GetHtml(markdown).Trim();

      // Assert
      Assert.That(result, Is.EqualTo("<p>This is some <strong>markdown</strong> which I am going to render.</p>"));
    }

    [Test,Description("This is a simple smoke-screen that the rendering process includes sanitisation.")]
    public void GetHtml_should_remove_an_unsafe_html_attribute_from_rendered_markdown()
    {
      // Arrange
      var markdown = "This is some markdown which has an <a onclick=\"do_something_bad\">unsafe attribute</a>.";

      // Act
      var result = Sut.GetHtml(markdown).Trim();

      // Assert
      Assert.That(result, Is.EqualTo("<p>This is some markdown which has an <a>unsafe attribute</a>.</p>"));
    }

    [Test]
    public void GetHtml_should_render_ticket_references_as_a_relative_ticket_link()
    {
      // Arrange
      var urlprovider = new Mock<IGetsTicketUri>();
      urlprovider
        .Setup(x => x.GetAbsoluteUri(It.Is<TicketReference>(t => t.ProjectCode == "AB" && t.TicketNumber == 12)))
        .Returns(() => new Uri("Ticket/Detail/11", UriKind.Relative));
      using(var scope = container.BeginLifetimeScope(b => b.RegisterInstance(urlprovider.Object)))
      {
        var markdown = "This is some markdown which contains #AB12 a ticket reference.";
        var sut = scope.Resolve<IRendersMarkdownToHtml>();

        // Act
        var result = sut.GetHtml(markdown).Trim();

        // Assert
        Assert.That(result, Does.Contain("<a"), "Link open tag");
        Assert.That(result, Does.Contain("</a>"), "Link close tag");
        Assert.That(result, Does.Contain("href=\"Ticket/Detail/11\""), "Link href");
        Assert.That(result, Does.Contain("title=\"Navigate to #AB12\""), "Link title");
        Assert.That(result, Does.Contain("class=\"ticket_link\""), "Link class");
        Assert.That(result, Does.Contain(">#AB12</a>"), "Link content");
      }
    }

    [Test]
    public void GetHtml_should_render_naked_ticket_references_as_a_relative_ticket_link()
    {
      // Arrange
      var project = new Project { Code = "AB" };
      var projectGetter = Mock.Of<ICurrentProjectGetter>(x => x.GetCurrentProject() == project);
      var urlprovider = new Mock<IGetsTicketUri>();
      urlprovider
        .Setup(x => x.GetAbsoluteUri(It.Is<TicketReference>(t => t.ProjectCode == null && t.TicketNumber == 12)))
        .Returns(() => new Uri("Ticket/Detail/11", UriKind.Relative));
      using(var scope = container.BeginLifetimeScope(b => {
            b.RegisterInstance(urlprovider.Object);
              b.RegisterInstance(projectGetter);
            }))
      {
        var markdown = "This is some markdown which contains #12 a naked ticket reference.";
        var sut = scope.Resolve<IRendersMarkdownToHtml>();

        // Act
        var result = sut.GetHtml(markdown).Trim();

        // Assert
        Assert.That(result, Does.Contain("<a"), "Link open tag");
        Assert.That(result, Does.Contain("</a>"), "Link close tag");
        Assert.That(result, Does.Contain("href=\"Ticket/Detail/11\""), "Link href");
        Assert.That(result, Does.Contain("title=\"Navigate to #12\""), "Link title");
        Assert.That(result, Does.Contain("class=\"ticket_link\""), "Link class");
        Assert.That(result, Does.Contain(">#12</a>"), "Link content");
      }
    }
  }
}
