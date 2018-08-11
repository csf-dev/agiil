using System;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Creation;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets.Creation
{
  [TestFixture,Parallelizable]
  public class LabelPopulatingTicketFactoryDecoratorTests
  {
    [Test,AutoMoqData]
    public void CreateTicket_adds_labels_from_label_provider([Frozen,CreatesATicket] ICreatesTicket wrapped,
                                                             [Frozen] IGetsLabels labelProvider,
                                                             Label labelOne,
                                                             Label labelTwo,
                                                             CreateTicketRequest request,
                                                             LabelPopulatingTicketFactoryDecorator sut)
    {
      // Arrange
      Mock.Get(labelProvider)
          .Setup(x => x.GetLabels(request.CommaSeparatedLabelNames))
          .Returns(new [] {labelOne, labelTwo});

      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result?.Labels, Contains.Item(labelOne), $"Contains {nameof(labelOne)}");
      Assert.That(result?.Labels, Contains.Item(labelTwo), $"Contains {nameof(labelTwo)}");
    }
  }
}
