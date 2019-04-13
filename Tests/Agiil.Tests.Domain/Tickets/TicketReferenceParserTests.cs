using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Parallelizable]
  public class TicketReferenceParserTests
  {
    [Test,AutoMoqData]
    public void ParseReferece_can_parse_a_reference_with_a_single_character_project_code_and_ticket_number(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece("B2");
      Assert.That(result, Is.EqualTo(new TicketReference("B", 2)));
    }

    [Test,AutoMoqData]
    public void ParseReferece_can_parse_a_reference_which_contains_an_ignored_leading_hash_symbol(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece("#B2");
      Assert.That(result, Is.EqualTo(new TicketReference("B", 2)));
    }

    [Test,AutoMoqData]
    public void ParseReferece_can_parse_a_reference_with_a_multi_character_project_code_and_ticket_number(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece("ABC998");
      Assert.That(result, Is.EqualTo(new TicketReference("ABC", 998)));
    }

    [Test,AutoMoqData]
    public void ParseRefernce_returns_null_for_a_null_input(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece(null);
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void ParseRefernce_returns_null_for_an_empty_string_input(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece(String.Empty);
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void ParseRefernce_returns_null_for_an_input_with_no_numeric_portion(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece("AAA");
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void ParseRefernce_returns_null_for_an_input_with_non_permitted_symbols(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece("AAA*333");
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void ParseRefernce_returns_null_for_an_input_with_leading_whitespace(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece(" B2");
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void ParseRefernce_returns_null_for_an_input_with_trailing_whitespace(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece("B2 ");
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void ParseRefernce_returns_a_partial_result_for_a_reference_without_a_project_code(TicketReferenceParser sut)
    {
      var result = sut.ParseReferece("2");
      Assert.That(result, Is.EqualTo(new TicketReference(null, 2)));
    }

    [Test, AutoMoqData]
    public void GetReference_from_valid_project_code_and_number_can_create_useful_reference(TicketReferenceParser sut)
    {
      var result = sut.GetReference("AB", 12);
      Assert.That(result, Is.EqualTo(new TicketReference("AB", 12)));
    }

    [Test, AutoMoqData]
    public void GetReference_from_invalid_project_code_and_number_can_create_useful_reference(TicketReferenceParser sut)
    {
      var result = sut.GetReference("A+B", 12);
      Assert.That(result, Is.Null);
    }

    [Test, AutoMoqData]
    public void GetReference_with_null_project_code_returns_partial_reference(TicketReferenceParser sut)
    {
      var result = sut.GetReference(null, 12);
      Assert.That(result, Is.EqualTo(new TicketReference(null, 12)));
    }

    [Test, AutoMoqData]
    public void GetReference_with_empty_string_project_code_returns_partial_reference(TicketReferenceParser sut)
    {
      var result = sut.GetReference(String.Empty, 12);
      Assert.That(result, Is.EqualTo(new TicketReference(null, 12)));
    }
  }
}
