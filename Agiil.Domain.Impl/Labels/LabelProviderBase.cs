using System;
using System.Collections.Generic;

namespace Agiil.Domain.Labels
{
  public abstract class LabelProviderBase : IGetsLabels
  {
    readonly IParsesLabelNames labelNameParser;

    public virtual IReadOnlyCollection<Label> GetLabels(string commaSeparatedLabelNames)
    {
      var names = labelNameParser.GetLabelNames(commaSeparatedLabelNames);
      return GetLabels(names);
    }

    public abstract IReadOnlyCollection<Label> GetLabels(IReadOnlyCollection<string> labelNames);

    protected LabelProviderBase(IParsesLabelNames labelNameParser)
    {
      if(labelNameParser == null)
        throw new ArgumentNullException(nameof(labelNameParser));

      this.labelNameParser = labelNameParser;
    }
  }
}
