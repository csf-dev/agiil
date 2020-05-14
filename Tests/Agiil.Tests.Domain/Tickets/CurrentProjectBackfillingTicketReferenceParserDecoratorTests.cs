using System;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Parallelizable]
  public class CurrentProjectBackfillingTicketReferenceParserDecoratorTests
  {
    [Test,AutoMoqData]
    public void ParseReferece_returns_the_result_from_the_wrapped_instance_when_it_is_complete([Frozen] IParsesTicketReference wrapped,
                                                                                               string input,
                                                                                               CurrentProjectBackfillingTicketReferenceParserDecorator sut)
    {
      var reference = new TicketReference("ABC", 123);
      Mock.Get(wrapped)
          .Setup(x => x.ParseReferece(input))
          .Returns(reference);
      var result = sut.ParseReferece(input);
      Assert.That(result, Is.SameAs(reference));
    }

    [Test,AutoMoqData]
    public void ParseReferece_backfills_current_project_code_when_it_is_empty([Frozen] IParsesTicketReference wrapped,
                                                                              [Frozen] IGetsCurrentProject projectProvider,
                                                                              string input,
                                                                              CurrentProjectBackfillingTicketReferenceParserDecorator sut)
    {
      var reference = new TicketReference(null, 10);
      Mock.Get(wrapped)
          .Setup(x => x.ParseReferece(input))
          .Returns(reference);
      Mock.Get(projectProvider)
          .Setup(x => x.GetCurrentProject())
          .Returns(new Project { Code = "ABC" });
      var result = sut.ParseReferece(input);
      Assert.That(result, Is.EqualTo(new TicketReference("ABC", 10)));
    }

    [Test, AutoMoqData]
    public void GetReference_backfills_current_project_code_when_it_is_empty([Frozen] IParsesTicketReference wrapped,
                                                                             [Frozen] IGetsCurrentProject projectProvider,
                                                                             CurrentProjectBackfillingTicketReferenceParserDecorator sut,
                                                                             TicketReference reference)
    {
      Mock.Get(wrapped)
          .Setup(x => x.GetReference("ABC", 10))
          .Returns(reference);
      Mock.Get(projectProvider)
          .Setup(x => x.GetCurrentProject())
          .Returns(new Project { Code = "ABC" });
      
      var result = sut.GetReference(null, 10);

      Assert.That(result, Is.SameAs(reference));
    }

    [Test, AutoMoqData]
    public void GetReference_does_not_backfill_current_project_code_when_it_is_provided([Frozen] IParsesTicketReference wrapped,
                                                                                        [Frozen] IGetsCurrentProject projectProvider,
                                                                                        CurrentProjectBackfillingTicketReferenceParserDecorator sut,
                                                                                        TicketReference reference)
    {
      Mock.Get(wrapped)
          .Setup(x => x.GetReference("DEF", 10))
          .Returns(reference);
      Mock.Get(projectProvider)
          .Setup(x => x.GetCurrentProject())
          .Returns(new Project { Code = "ABC" });

      var result = sut.GetReference("DEF", 10);

      Assert.That(result, Is.SameAs(reference));
    }
  }
}
