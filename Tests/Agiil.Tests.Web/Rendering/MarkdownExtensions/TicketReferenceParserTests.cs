using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Ext = Agiil.Web.Rendering.MarkdownExtensions;
using Markdig.Helpers;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Web.Rendering.MarkdownExtensions
{
  public class TicketReferenceParserTests
  {
    [Test,AutoMoqData]
    public void GetTicketReference_parses_reference_with_project_code_and_ticket_number([Frozen] IParsesTicketReference innerParser,
                                                                                           Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#AB12");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece("AB12"), Times.Once);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_parses_reference_with_long_project_code_and_ticket_number([Frozen] IParsesTicketReference innerParser,
                                                                                                Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABCD1234");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece("ABCD1234"), Times.Once);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_parses_naked_ticket_number_without_project_code([Frozen] IParsesTicketReference innerParser,
                                                                                      Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#1234");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece("1234"), Times.Once);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_parses_reference_followed_by_whitespace([Frozen] IParsesTicketReference innerParser,
                                                                              Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#1234 ");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece("1234"), Times.Once);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_parses_reference_followed_by_a_period([Frozen] IParsesTicketReference innerParser,
                                                                            Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#1234.");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece("1234"), Times.Once);
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
      var parser = Mock.Of<IParsesTicketReference>();
      var reference = new TicketReference();
      var ticketRefWithoutOtherChars = System.Text.RegularExpressions.Regex.Replace(ticketRef, @"[^0-9A-Za-z]+", String.Empty);
      Mock.Get(parser)
          .Setup(x => x.ParseReferece(ticketRefWithoutOtherChars))
          .Returns(reference);
      var sut = new Ext.TicketReferenceParser(parser);
      var iterator = new StringSlice(ticketRef);
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(charCount, Is.EqualTo(expectedChars));
    }

    [Test,AutoMoqData]
    public void GetTicketReference_does_not_parse_if_first_char_is_not_hash_symbol([Frozen] IParsesTicketReference innerParser,
                                                                                 Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("*1234");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece(It.IsAny<string>()), Times.Never);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_does_not_parse_if_no_numbers_after_alphabetic_letters([Frozen] IParsesTicketReference innerParser,
                                                                                       Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABC");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece(It.IsAny<string>()), Times.Never);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_does_not_parse_if_there_is_whitespace_between_project_code_and_ticket_number([Frozen] IParsesTicketReference innerParser,
                                                                                                              Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABC 123");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece(It.IsAny<string>()), Times.Never);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_does_not_parse_if_there_is_a_dash_between_project_code_and_ticket_number([Frozen] IParsesTicketReference innerParser,
                                                                                                          Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABC-123");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece(It.IsAny<string>()), Times.Never);
    }

    [Test,AutoMoqData]
    public void GetTicketReference_does_not_parse_if_there_are_further_alpha_characters_after_the_ticket_number([Frozen] IParsesTicketReference innerParser,
                                                                                                              Ext.TicketReferenceParser sut)
    {
      // Arrange
      var iterator = new StringSlice("#ABC123DEF");
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Mock.Get(innerParser)
          .Verify(x => x.ParseReferece(It.IsAny<string>()), Times.Never);
    }

    [TestCase("*1234")]
    [TestCase("#ABC")]
    [TestCase("#ABC 123")]
    [TestCase("#ABC-123")]
    [TestCase("#ABC123DEF")]
    public void GetTicketReference_returns_correct_number_of_characters_consumed_in_bogus_reference(string ticketRef)
    {
      // Arrange
      var parser = Mock.Of<IParsesTicketReference>();
      Mock.Get(parser)
          .Setup(x => x.ParseReferece(ticketRef))
          .Returns(() => null);
      var sut = new Ext.TicketReferenceParser(parser);
      var iterator = new StringSlice(ticketRef);
      int charCount;

      // Act
      sut.GetTicketReference(iterator, out charCount);

      // Assert
      Assert.That(charCount, Is.Zero);
    }
  }
}
