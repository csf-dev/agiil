using System;
using Agiil.Domain.Activity;
using Agiil.Tests.Attributes;
using NUnit.Framework;

namespace Agiil.Tests.Activity
{
  [TestFixture,Parallelizable]
  public class TimeSpanParserTests
  {
    [Test,AutoMoqData]
    public void GetTimeSpan_returns_empty_time_for_zero_minutes(TimeSpanParser sut)
    {
      AssertParsedAs("0m", TimeSpan.Zero, sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_returns_empty_time_for_zero_hours(TimeSpanParser sut)
    {
      AssertParsedAs("0h", TimeSpan.Zero, sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_returns_empty_time_for_zero_without_units(TimeSpanParser sut)
    {
      AssertParsedAs("0", TimeSpan.Zero, sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_can_parse_6_minutes(TimeSpanParser sut)
    {
      AssertParsedAs("6m", TimeSpan.FromMinutes(6), sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_can_parse_2_hours(TimeSpanParser sut)
    {
      AssertParsedAs("2h", TimeSpan.FromHours(2), sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_can_parse_90_minutes(TimeSpanParser sut)
    {
      AssertParsedAs("90m", TimeSpan.FromMinutes(90), sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_can_parse_1_hour_5_minutes_with_a_comma_separating_portions(TimeSpanParser sut)
    {
      AssertParsedAs("1h,5m", TimeSpan.FromMinutes(65), sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_can_parse_1_hour_5_minutes_with_a_comma_and_a_space_separating_portions(TimeSpanParser sut)
    {
      AssertParsedAs("1h, 5m", TimeSpan.FromMinutes(65), sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_can_parse_1_hour_5_minutes_with_a_space_separating_portions(TimeSpanParser sut)
    {
      AssertParsedAs("1h 5m", TimeSpan.FromMinutes(65), sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_can_parse_1_hour_5_minutes_with_nothing_separating_portions(TimeSpanParser sut)
    {
      AssertParsedAs("1h5m", TimeSpan.FromMinutes(65), sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_can_parse_6_minutes_4_minutes_and_5_minutes_with_multiple_spaces_separating_portions(TimeSpanParser sut)
    {
      AssertParsedAs("   6m   4m  5m ", TimeSpan.FromMinutes(15), sut);
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_throws_FormatException_for_junk_data(TimeSpanParser sut)
    {
      Assert.That(() => sut.GetTimeSpan("Junk"), Throws.InstanceOf<FormatException>());
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_throws_FormatException_for_empty_string(TimeSpanParser sut)
    {
      Assert.That(() => sut.GetTimeSpan(String.Empty), Throws.InstanceOf<FormatException>());
    }

    [Test,AutoMoqData]
    public void GetTimeSpan_throws_ANE_for_null(TimeSpanParser sut)
    {
      Assert.That(() => sut.GetTimeSpan(null), Throws.InstanceOf<ArgumentNullException>());
    }

    void AssertParsedAs(string input, TimeSpan expected, IParsesTimespan sut)
    {
      var result = sut.GetTimeSpan(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
