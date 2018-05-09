using System;
using System.Collections.Generic;
using Agiil.Domain.Labels;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Labels
{
  [TestFixture,Parallelizable]
  public class ExistingAndNewLabelProviderTests
  {
    [Test,AutoMoqData]
    public void GetLabels_returns_results_from_existing_provider(IGetsLabels existingProvider,
                                                                 IGetsLabels newProvider,
                                                                 IParsesLabelNames nameParser,
                                                                 Label existingLabel)
    {
      // Arrange
      Mock.Get(existingProvider)
          .Setup(x => x.GetLabels(It.IsAny<IReadOnlyCollection<string>>()))
          .Returns(new [] { existingLabel });
      Mock.Get(newProvider)
          .Setup(x => x.GetLabels(It.IsAny<IReadOnlyCollection<string>>()))
          .Returns(new Label[0]);
      var sut = new ExistingAndNewLabelProvider(existingProvider, newProvider, nameParser);

      // Act
      var result = sut.GetLabels(new [] { existingLabel.Name });

      // Assert
      Assert.That(result, Has.Exactly(1).SameAs(existingLabel));
    }

    [Test,AutoMoqData]
    public void GetLabels_returns_results_from_new_provider(IGetsLabels existingProvider,
                                                            IGetsLabels newProvider,
                                                            IParsesLabelNames nameParser,
                                                            Label newLabel)
    {
      // Arrange
      Mock.Get(existingProvider)
          .Setup(x => x.GetLabels(It.IsAny<IReadOnlyCollection<string>>()))
          .Returns(new Label[0]);
      Mock.Get(newProvider)
          .Setup(x => x.GetLabels(It.IsAny<IReadOnlyCollection<string>>()))
          .Returns(new [] { newLabel });
      var sut = new ExistingAndNewLabelProvider(existingProvider, newProvider, nameParser);

      // Act
      var result = sut.GetLabels(new [] { newLabel.Name });

      // Assert
      Assert.That(result, Has.Exactly(1).SameAs(newLabel));
    }

    [Test,AutoMoqData]
    public void GetLabels_does_not_pass_name_to_new_provider_if_it_has_an_existing_label(IGetsLabels existingProvider,
                                                                                         IGetsLabels newProvider,
                                                                                         IParsesLabelNames nameParser,
                                                                                         Label existingLabel)
    {
      // Arrange
      Mock.Get(existingProvider)
          .Setup(x => x.GetLabels(It.IsAny<IReadOnlyCollection<string>>()))
          .Returns(new [] { existingLabel });
      Mock.Get(newProvider)
          .Setup(x => x.GetLabels(It.IsAny<IReadOnlyCollection<string>>()))
          .Returns(new Label[0]);
      var sut = new ExistingAndNewLabelProvider(existingProvider, newProvider, nameParser);

      // Act
      sut.GetLabels(new [] { existingLabel.Name });

      // Assert
      Mock.Get(newProvider)
          .Verify(x => x.GetLabels(It.Is<IReadOnlyCollection<string>>(c => c.Count == 0)), Times.Once);
    }

    [Test,AutoMoqData]
    public void GetLabels_passes_name_to_new_provider_if_it_does_not_have_an_existing_label(IGetsLabels existingProvider,
                                                                                            IGetsLabels newProvider,
                                                                                            IParsesLabelNames nameParser,
                                                                                            string labelName)
    {
      // Arrange
      Mock.Get(existingProvider)
          .Setup(x => x.GetLabels(It.IsAny<IReadOnlyCollection<string>>()))
          .Returns(new Label[0]);
      Mock.Get(newProvider)
          .Setup(x => x.GetLabels(It.IsAny<IReadOnlyCollection<string>>()))
          .Returns(new Label[0]);
      var sut = new ExistingAndNewLabelProvider(existingProvider, newProvider, nameParser);

      // Act
      sut.GetLabels(new [] { labelName });

      // Assert
      Mock.Get(newProvider)
          .Verify(x => x.GetLabels(It.Is<IReadOnlyCollection<string>>(c => c.Count == 1)), Times.Once);
    }

  }
}
