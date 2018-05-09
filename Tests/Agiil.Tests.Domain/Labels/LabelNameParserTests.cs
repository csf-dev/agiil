using System;
using Agiil.Domain.Labels;
using Agiil.Tests.Attributes;
using NUnit.Framework;

namespace Agiil.Tests.Labels
{
  [TestFixture,Parallelizable]
  public class LabelNameParserTests
  {
    [Test,AutoMoqData]
    public void GetLabelNames_returns_empty_collection_for_null_input(LabelNameParser sut)
    {
      // Act
      var result = sut.GetLabelNames(null);

      // Assert
      Assert.That(result.Count, Is.EqualTo(0), "Count of items");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_returns_empty_collection_for_empty_string_input(LabelNameParser sut)
    {
      // Act
      var result = sut.GetLabelNames(String.Empty);

      // Assert
      Assert.That(result.Count, Is.EqualTo(0), "Count of items");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_returns_empty_collection_for_empty_whitespace_input(LabelNameParser sut)
    {
      // Act
      var result = sut.GetLabelNames("  ");

      // Assert
      Assert.That(result.Count, Is.EqualTo(0), "Count of items");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_can_get_a_single_simple_label_name(LabelNameParser sut)
    {
      // Arrange
      var names = "labelname";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(1), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("labelname"), "First item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_normalises_names_to_lowercase(LabelNameParser sut)
    {
      // Arrange
      var names = "LABELNAME";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(1), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("labelname"), "First item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_discards_leading_and_trailing_whitespace(LabelNameParser sut)
    {
      // Arrange
      var names = "   labelname   ";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(1), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("labelname"), "First item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_can_get_a_single_label_name_which_has_a_space(LabelNameParser sut)
    {
      // Arrange
      var names = "label name";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(1), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("label name"), "First item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_can_get_three_labels_with_spaces(LabelNameParser sut)
    {
      // Arrange
      var names = "label one,label two,label three";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(3), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("label one"), "First item");
      Assert.That(result, Has.Exactly(1).EqualTo("label two"), "Second item");
      Assert.That(result, Has.Exactly(1).EqualTo("label three"), "Third item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_can_get_three_labels_with_spaces_and_trimmed_whitespace(LabelNameParser sut)
    {
      // Arrange
      var names = "label one  ,  label two, label three";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(3), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("label one"), "First item");
      Assert.That(result, Has.Exactly(1).EqualTo("label two"), "Second item");
      Assert.That(result, Has.Exactly(1).EqualTo("label three"), "Third item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_discards_empty_label_names(LabelNameParser sut)
    {
      // Arrange
      var names = "label one  ,  , label three";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(2), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("label one"), "First item");
      Assert.That(result, Has.Exactly(1).EqualTo("label three"), "Third item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_discards_duplicate_label_names(LabelNameParser sut)
    {
      // Arrange
      var names = "label one,label one";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(1), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("label one"), "First item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_discards_duplicates_with_case_insensitive_matching(LabelNameParser sut)
    {
      // Arrange
      var names = "label one,LABEL ONE";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(1), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("label one"), "First item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_discards_duplicates_after_whitespace_has_been_normalised(LabelNameParser sut)
    {
      // Arrange
      var names = "label one,LABEL     ONE";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(1), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("label one"), "First item");
    }

    [Test,AutoMoqData]
    public void GetLabelNames_normalises_repeated_whitespace_to_a_single_space(LabelNameParser sut)
    {
      // Arrange
      var names = "label one  ,  label         two, label three";

      // Act
      var result = sut.GetLabelNames(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(3), "Count of items");
      Assert.That(result, Has.Exactly(1).EqualTo("label one"), "First item");
      Assert.That(result, Has.Exactly(1).EqualTo("label two"), "Second item");
      Assert.That(result, Has.Exactly(1).EqualTo("label three"), "Third item");
    }
  }
}
