using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Agiil.Domain.Labels;

namespace Agiil.Web.ApiControllers
{
  public class LabelsController : ApiController
  {
    readonly Lazy<ISearchesForLabels> labelProvider;

    public IList<ListedLabel> Get(string q = null, int? max = null)
    {
      return labelProvider.Value.GetLabels(q, max ?? 10).ToArray();
    }

    public LabelsController(Lazy<ISearchesForLabels> labelProvider)
    {
      if(labelProvider == null)
        throw new ArgumentNullException(nameof(labelProvider));
      this.labelProvider = labelProvider;
    }
  }
}
