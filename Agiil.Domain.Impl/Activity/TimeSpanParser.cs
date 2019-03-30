using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Agiil.Domain.Activity
{
  public class TimeSpanParser : IParsesTimespan
  {
    const string ZeroTime = "0";
    const string TimeAmountPattern = @"^[, ]*(\d+)([hm])([, ]*((\d+)([hm])))*[, ]*$";
    static readonly Regex TimeAmountMatcher = new Regex(TimeAmountPattern,
                                                        RegexOptions.Compiled
                                                        | RegexOptions.CultureInvariant
                                                        | RegexOptions.IgnoreCase);

    public TimeSpan GetTimeSpan(string timeAmount)
    {
      if(timeAmount == null)
        throw new ArgumentNullException(nameof(timeAmount));
      if(timeAmount.Length == 0) throw new FormatException("Empty string is not permitted");
      if(timeAmount == ZeroTime) return TimeSpan.Zero;

      var match = TimeAmountMatcher.Match(timeAmount);
      if(!match.Success)
        throw new FormatException("Invalid time-amount format");

      var components = GetTimeComponents(match);

      return components.Aggregate(TimeSpan.Zero, (acc, next) => acc + ParseTimeComponent(next));
    }

    IEnumerable<TimeComponent> GetTimeComponents(Match match)
    {
      var output = new List<TimeComponent>();

      var firstComponent = new TimeComponent { Amount = match.Groups[1].Value, Units = match.Groups[2].Value };

      var otherComponents = match.Groups[4].Captures
        .Cast<Capture>()
        .Select((capture, idx) => new TimeComponent { Amount = match.Groups[5].Captures[idx].Value,
                                                      Units = match.Groups[6].Captures[idx].Value })
        .ToArray();

      output.Add(firstComponent);
      output.AddRange(otherComponents);

      return output.ToArray();
    }

    TimeSpan ParseTimeComponent(TimeComponent component)
    {
      var amount = Double.Parse(component.Amount);

      switch(component.Units.ToLowerInvariant())
      {
      case "m":
        return TimeSpan.FromMinutes(amount);
      case "h":
        return TimeSpan.FromHours(amount);
      default:
        throw new InvalidOperationException("Unsupported units value in a time");
      }
    }

    class TimeComponent
    {
      public string Amount { get; set; }
      public string Units { get; set; }
    }
  }
}
