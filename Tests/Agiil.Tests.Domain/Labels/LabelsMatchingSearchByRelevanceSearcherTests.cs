using System;
using System.Linq;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using CSF.Collections;
using CSF.ORM;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Labels
{
  [TestFixture,Parallelizable]
  public class LabelsMatchingSearchByRelevanceSearcherTests
  {
    [Test,AutoMoqData]
    public void GetLabels_returns_a_label_which_is_an_exact_match_for_the_quer([Frozen,InMemory] IEntityData entityData,
                                                                               LabelsMatchingSearchByRelevanceSearcher sut,
                                                                               Label label)
    {
      // Arrange
      label.Name = "Elephant";
      entityData.Add(label);

      // Act
      var result = sut.GetLabels("Elephant");

      // Assert
      Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test,AutoMoqData]
    public void GetLabels_returns_a_label_which_starts_with_the_query([Frozen,InMemory] IEntityData entityData,
                                                                      LabelsMatchingSearchByRelevanceSearcher sut,
                                                                      Label label)
    {
      // Arrange
      label.Name = "Elephant";
      entityData.Add(label);

      // Act
      var result = sut.GetLabels("Ele");

      // Assert
      Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test,AutoMoqData]
    public void GetLabels_returns_a_label_which_contains_the_query([Frozen,InMemory] IEntityData entityData,
                                                                   LabelsMatchingSearchByRelevanceSearcher sut,
                                                                   Label label)
    {
      // Arrange
      label.Name = "Elephant";
      entityData.Add(label);

      // Act
      var result = sut.GetLabels("pha");

      // Assert
      Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test,AutoMoqData]
    public void GetLabels_does_not_return_a_label_which_does_not_match_the_query([Frozen,InMemory] IEntityData entityData,
                                                                                 LabelsMatchingSearchByRelevanceSearcher sut,
                                                                                 Label label)
    {
      // Arrange
      label.Name = "Elephant";
      entityData.Add(label);

      // Act
      var result = sut.GetLabels("zzz");

      // Assert
      Assert.That(result.Count, Is.EqualTo(0));
    }

    [Test,AutoMoqData]
    public void GetLabels_returns_labels_in_relevance_order([Frozen,InMemory] IEntityData entityData,
                                                            LabelsMatchingSearchByRelevanceSearcher sut,
                                                            Label label1,
                                                            Label label2,
                                                            Label label3,
                                                            Label label4)
    {
      // Arrange
      label1.Name = "Element";
      label2.Name = "Elemental";
      label3.Name = "Fire Elemental";
      label4.Name = "Zebra";
      entityData.Add(label4);
      entityData.Add(label3);
      entityData.Add(label1);
      entityData.Add(label2);

      // Act
      var result = sut.GetLabels("Element");

      // Assert
      var labelNames = result.Select(x => x.Name).ToArray();
      Assert.That(labelNames, Is.EqualTo(new [] { "Element", "Elemental", "Fire Elemental" }));
    }
  }
}
