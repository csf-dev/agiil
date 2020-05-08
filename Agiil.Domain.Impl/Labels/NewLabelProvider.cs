using System;
using System.Collections.Generic;
using System.Linq;
using CSF.ORM;

namespace Agiil.Domain.Labels
{
  public class NewLabelProvider : LabelProviderBase
  {
    readonly IEntityData entityData;
    readonly ICreatesLabel labelFactory;

    public override IReadOnlyCollection<Label> GetLabels(IReadOnlyCollection<string> labelNames)
    {
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));
      
      return labelNames.Select(CreateAndSaveLabel).ToList();
    }

    Label CreateAndSaveLabel(string name)
    {
      var label = labelFactory.CreateLabel(name);
      entityData.Add(label);
      return label;
    }

    public NewLabelProvider(IEntityData entityData,
                            ICreatesLabel labelFactory,
                            IParsesLabelNames labelNameParser) : base(labelNameParser)
    {
      if(entityData == null)
        throw new ArgumentNullException(nameof(entityData));
      if(labelFactory == null)
        throw new ArgumentNullException(nameof(labelFactory));
      
      this.entityData = entityData;
      this.labelFactory = labelFactory;
    }
  }
}
