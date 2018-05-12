using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Labels;
using Agiil.Web.Models.Labels;
using AutoMapper;

namespace Agiil.Web.Controllers
{
  public class LabelsController : Controller
  {
    readonly IGetsListOfLabels labelLister;
    readonly IMapper mapper;

    public ActionResult Index()
    {
      var labels = labelLister.GetAllLabels();
      var model = new ListOfLabelsModel {
        Labels = labels.Select(x => mapper.Map<ListedLabelDto>(x)).ToArray()
      };
      return View(model);
    }

    public LabelsController(IGetsListOfLabels labelLister, IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(labelLister == null)
        throw new ArgumentNullException(nameof(labelLister));
      this.labelLister = labelLister;
      this.mapper = mapper;
    }
  }
}
