using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Agiil.Web.Rendering.MarkdownExtensions;
using Markdig.Helpers;
using NUnit.Framework;

namespace Agiil.Tests.Web.Rendering.MarkdownExtensions
{
  public class TicketReferenceParserTests
  {
    [Test,AutoMoqData]
    public void GetTicketReference_can_parse_reference_with_project_code_and_ticket_number(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#AB12");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result?.ProjectCode, Is.EqualTo("AB"), nameof(TicketReference.ProjectCode));
      Assert.That(result?.TicketNumber, Is.EqualTo(12), nameof(TicketReference.TicketNumber));
    }

    [Test,AutoMoqData]
    public void GetTicketReference_can_parse_reference_with_long_project_code_and_ticket_number(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABCD1234");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result?.ProjectCode, Is.EqualTo("ABCD"), nameof(TicketReference.ProjectCode));
      Assert.That(result?.TicketNumber, Is.EqualTo(1234), nameof(TicketReference.TicketNumber));
    }

    [Test,AutoMoqData]
    public void GetTicketReference_can_parse_naked_ticket_number_without_project_code(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#1234");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result?.ProjectCode, Is.Null, nameof(TicketReference.ProjectCode));
      Assert.That(result?.TicketNumber, Is.EqualTo(1234), nameof(TicketReference.TicketNumber));
    }

    [Test,AutoMoqData]
    public void GetTicketReference_can_parse_reference_followed_by_whitespace(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#1234 ");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result?.ProjectCode, Is.Null, nameof(TicketReference.ProjectCode));
      Assert.That(result?.TicketNumber, Is.EqualTo(1234), nameof(TicketReference.TicketNumber));
    }

    [Test,AutoMoqData]
    public void GetTicketReference_can_parse_reference_followed_by_a_period(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#1234.");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result?.ProjectCode, Is.Null, nameof(TicketReference.ProjectCode));
      Assert.That(result?.TicketNumber, Is.EqualTo(1234), nameof(TicketReference.TicketNumber));
    }

    //        Ref           Chars
    //        ---           -----
    [TestCase("#AB12",      5)]
    [TestCase("#ABCD1234",  9)]
    [TestCase("#123",       4)]
    [TestCase("#1234 ",     5)]
    [TestCase("#1234.",     5)]
    public void GetTicketReference_returns_correct_number_of_characters_consumed_in_reference(string ticketRef,
                                                                                              int expectedChars)
    {
      // Arrange
      var sut = new TicketReferenceParser();
      var iterator = new StringSlice(ticketRef);
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(charCount, Is.EqualTo(expectedChars));
    }

    [Test,AutoMoqData]
    public void GetTicketReference_returns_null_if_first_char_is_not_hash_symbol(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("*1234");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_returns_null_if_no_numbers_after_alphabetic_letters(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABC");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_returns_null_if_there_is_whitespace_between_project_code_and_ticket_number(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABC 123");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_returns_null_if_there_is_a_dash_between_project_code_and_ticket_number(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABC-123");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_returns_null_if_there_are_further_alpha_characters_after_the_ticket_number(TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABC123DEF");
      int charCount;

      // Act
      var result = sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(result, Is.Null);
    }

    [TestCase("*1234")]
    [TestCase("#ABC")]
    [TestCase("#ABC 123")]
    [TestCase("#ABC-123")]
    [TestCase("#ABC123DEF")]
    public void GetTicketReference_returns_correct_number_of_characters_consumed_in_bogus_reference(string ticketRef)
    {
      // Arrange
      var sut = new TicketReferenceParser();
      var iterator = new StringSlice(ticketRef);
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(charCount, Is.Zero);
    }
  }
}
