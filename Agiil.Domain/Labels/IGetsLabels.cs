using System;
using System.Collections.Generic;

namespace Agiil.Domain.Labels
{
  public interface IGetsLabels
  {
    IReadOnlyCollection<Label> GetLabels(string commaSeparatedLabelNames);
    IReadOnlyCollection<Label> GetLabels(IReadOnlyCollection<string> labelNames);
  }
}
