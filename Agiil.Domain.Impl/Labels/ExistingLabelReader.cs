using System;
using System.Linq;
using CSF.Data.Entities;
using CSF.Data.NHibernate;

namespace Agiil.Domain.Labels
{
  public class ExistingLabelReader : IGetsExistingLabel
  {
    readonly IEntityData data;

    public Label GetLabel(string name)
    {
      if(String.IsNullOrEmpty(name)) return null;

      return data.Query<Label>()
                 .Where(x => x.Name == name)
                 .FetchMany(x => x.Tickets)
                 .AsEnumerable()
                 .FirstOrDefault();
    }

    public ExistingLabelReader(IEntityData data)
    {
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      this.data = data;
    }
  }
}
