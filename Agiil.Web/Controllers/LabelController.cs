using System;
using System.Web.Mvc;
using Agiil.Web.Models.Labels;
using Agiil.Web.Services.Labels;

namespace Agiil.Web.Controllers
{
  public class LabelController : Controller
  {
    readonly IGetsLabelDetail labelProvider;

    [HttpGet]
    public ActionResult Index(string id)
    {
      var label = labelProvider.GetLabelDetail(id);
      if(label == null) return HttpNotFound();

      var model = new LabelDetailModel { Label = label };
      return View(model);
    }

    public LabelController(IGetsLabelDetail labelProvider)
    {
      if(labelProvider == null)
        throw new ArgumentNullException(nameof(labelProvider));
      this.labelProvider = labelProvider;
    }
  }
}
