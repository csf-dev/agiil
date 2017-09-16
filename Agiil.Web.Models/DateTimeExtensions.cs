using System;
namespace Agiil.Web.Models
{
  public static class DateTimeExtensions
  {
    public static string ToWebDateValue(this DateTime date) => date.ToString("yyyy-MM-dd");

    public static string ToWebDateValue(this DateTime? date)
    {
      if(!date.HasValue)
        return String.Empty;

      return date.Value.ToWebDateValue();
    }
  }
}
