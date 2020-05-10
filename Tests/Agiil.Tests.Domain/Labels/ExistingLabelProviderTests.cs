using System;
using System.Collections.Generic;
using Agiil.Domain.Labels;
using Agiil.Tests.Attributes;
using CSF.ORM;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Labels
{
  [TestFixture,Parallelizable]
  public class ExistingLabelProviderTests
  {
    [Test,AutoMoqData]
    public void GetLabels_returns_a_matching_label([Frozen,InMemory] IEntityData entityData,
                                                   ExistingLabelProvider sut,
                                                   Label label)
    {
      // Arrange
      entityData.Add(label);

      // Act
      var result = sut.GetLabels(new [] { label.Name });

      // Assert
      Assert.That(result, Has.Exactly(1).SameAs(label));
    }

    [Test,AutoMoqData]
    public void GetLabels_does_not_return_a_non_matching_label([Frozen,InMemory] IEntityData entityData,
                                                               ExistingLabelProvider sut,
                                                               Label label,
                                                               string labelName)
    {
      // Arrange
      entityData.Add(label);

      // Act
      var result = sut.GetLabels(new [] { labelName });

      // Assert
      Assert.That(result, Is.Empty);
    }
  }
}
