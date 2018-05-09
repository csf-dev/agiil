using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Domain.Labels
{
  public class ExistingAndNewLabelProvider : LabelProviderBase
  {
    readonly IGetsLabels existingLabelProvider, newLabelProvider;

    public override IReadOnlyCollection<Label> GetLabels(IReadOnlyCollection<string> labelNames)
    {
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));
      
      var existingLabels = existingLabelProvider.GetLabels(labelNames);
      var missingNames = GetMissingLabelNames(labelNames, existingLabels);
      var newLabels = newLabelProvider.GetLabels(missingNames);

      return existingLabels.Union(newLabels).ToList();
    }

    IReadOnlyCollection<string> GetMissingLabelNames(IEnumerable<string> names, IEnumerable<Label> existingLabels)
    {
      return names.Except(existingLabels.Select(x => x.Name)).ToList();
    }

    public ExistingAndNewLabelProvider(IGetsLabels existingLabelProvider,
                                       IGetsLabels newLabelProvider,
                                       IParsesLabelNames labelNameParser) : base(labelNameParser)
    {
      if(existingLabelProvider == null)
        throw new ArgumentNullException(nameof(existingLabelProvider));
      if(newLabelProvider == null)
        throw new ArgumentNullException(nameof(newLabelProvider));

      this.existingLabelProvider = existingLabelProvider;
      this.newLabelProvider = newLabelProvider;
    }
  }
}
