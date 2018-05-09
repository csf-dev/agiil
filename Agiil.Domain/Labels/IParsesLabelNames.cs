using System;
using System.Collections.Generic;

namespace Agiil.Domain.Labels
{
  public interface IParsesLabelNames
  {
    IReadOnlyCollection<string> GetLabelNames(string commaSeparatedLabelNames);

    string GetCommaSeparatedLabelNames(IEnumerable<string> labelNames);
    string GetCommaSeparatedLabelNames(IEnumerable<Label> labels);
  }
}
