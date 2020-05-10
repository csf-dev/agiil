using Agiil.Domain.Labels;
using Agiil.Domain.Labels.Specs;
using Agiil.Tests.Attributes;
using NUnit.Framework;
using System;
using CSF.Specifications;

namespace Agiil.Tests.Labels.Specs
{
  [TestFixture,Parallelizable]
  public class LabelNameInTests
  {
    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_label_with_one_of_the_specified_names(string nameOne,
                                                                                 string nameTwo,
                                                                                 Label label)
    {
      // Arrange
      var sut = new LabelNameIn(new [] { nameOne, nameTwo });
      label.Name = nameOne;

      // Act
      var result = sut.Matches(label);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_label_without_one_of_the_specified_names(string nameOne,
                                                                                    string nameTwo,
                                                                                    string nameThree,
                                                                                    Label label)
    {
      // Arrange
      var sut = new LabelNameIn(new [] { nameOne, nameTwo });
      label.Name = nameThree;

      // Act
      var result = sut.Matches(label);

      // Assert
      Assert.That(result, Is.False);
    }
  }
}
