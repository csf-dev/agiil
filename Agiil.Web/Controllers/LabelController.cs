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
  public class LabelController : Controller
  {
    readonly IGetsExistingLabel labelReader;
    readonly IMapper mapper;

    [HttpGet]
    public ActionResult Index(string id)
    {
      var label = labelReader.GetLabel(id);
      if(label == null) return HttpNotFound();

      var labelDto = mapper.Map<LabelDetailDto>(label);
      var model = new LabelDetailModel { Label = labelDto };

      return View(model);
    }

    public LabelController(IGetsExistingLabel labelReader, IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(labelReader == null)
        throw new ArgumentNullException(nameof(labelReader));
      this.labelReader = labelReader;
      this.mapper = mapper;
    }
  }
}
