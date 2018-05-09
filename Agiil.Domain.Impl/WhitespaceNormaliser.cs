using System.Text.RegularExpressions;

namespace Agiil.Domain
{
  static class WhitespaceNormaliser
  {
    const string
      RepeatedWhitespacePattern = @"\s+",
      SingleSpace = " ";

    static readonly Regex RepeatedWhitespace = new Regex(RepeatedWhitespacePattern, RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public static string NormaliseWhitespace(this string val)
    {
      if(val == null) return null;

      return RepeatedWhitespace.Replace(val, SingleSpace);
    }
  }
}
