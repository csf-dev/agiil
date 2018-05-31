using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Domain.Labels
{
  public class LabelNameParser : IParsesLabelNames
  {
    const char Separator = ',';

    public IReadOnlyCollection<string> GetLabelNames(string commaSeparatedLabelNames)
    {
      if(String.IsNullOrWhiteSpace(commaSeparatedLabelNames))
        return Enumerable.Empty<string>().ToArray();

      return commaSeparatedLabelNames
        .Split(Separator)
        .Select(x => x.Trim().ToLowerInvariant().NormaliseWhitespace())
        .Where(x => !String.IsNullOrEmpty(x))
        .Distinct()
        .ToList();
    }

    public string GetCommaSeparatedLabelNames(IEnumerable<string> labelNames)
    {
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));

      var sanitisedLabelNames = labelNames
        .Where(x => !String.IsNullOrWhiteSpace(x))
        .Select(x => x.Trim().ToLowerInvariant().NormaliseWhitespace())
        .ToList();

      return String.Join(Separator.ToString(), sanitisedLabelNames);
    }

    public string GetCommaSeparatedLabelNames(IEnumerable<Label> labels)
    {
      if(labels == null)
        throw new ArgumentNullException(nameof(labels));
      
      return GetCommaSeparatedLabelNames(labels.Select(x => x.Name).ToList());
    }
  }
}
