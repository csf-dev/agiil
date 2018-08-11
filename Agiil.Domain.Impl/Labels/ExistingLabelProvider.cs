using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Labels.Specs;
using CSF.Data.Entities;
using CSF.Data.Specifications;

namespace Agiil.Domain.Labels
{
  public class ExistingLabelProvider : LabelProviderBase
  {
    readonly IEntityData entityData;

    public override IReadOnlyCollection<Label> GetLabels(IReadOnlyCollection<string> labelNames)
    {
      var spec = new LabelNameIn(labelNames);
      return entityData.Query<Label>().Where(spec).ToList();
    }

    public ExistingLabelProvider(IEntityData entityData,
                                 IParsesLabelNames labelNameParser) : base(labelNameParser)
    {
      if(entityData == null)
        throw new ArgumentNullException(nameof(entityData));

      this.entityData = entityData;
    }
  }
}
