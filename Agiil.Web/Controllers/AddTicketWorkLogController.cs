﻿using System;
using System.Web.Mvc;
using Agiil.Domain.Activity;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Activity;
using AutoMapper;

namespace Agiil.Web.Controllers
{
  public class AddTicketWorkLogController : Controller
  {
    static readonly string ModelKey = nameof(AddTicketWorkLogModel);

    readonly IMapper mapper;
    readonly IAddsWorkLogForTicket logger;
    readonly ICurrentUserReader userProvider;

    public AddTicketWorkLogController(IMapper mapper,
                                      IAddsWorkLogForTicket logger,
                                      ICurrentUserReader userProvider)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(logger == null)
        throw new ArgumentNullException(nameof(logger));
      if(userProvider == null)
        throw new ArgumentNullException(nameof(userProvider));
      this.mapper = mapper;
      this.logger = logger;
      this.userProvider = userProvider;
    }

    [HttpGet]
    public ActionResult Index(TicketReference id)
    {
      var model = GetModel(id);
      return View(model);
    }

    [HttpPost]
    public ActionResult AddWorklog(AddTicketWorkLogModel model)
    {
      TempData.Clear();

      var request = mapper.Map<AddWorkLogRequest>(model);
      request.User = userProvider.RequireCurrentUser();

      var result = logger.AddWorkLog(request);
      if(result.Success)
        return RedirectToAction(nameof(TicketController.Index),
                                typeof(TicketController).AsControllerName(),
                                new { id = model.TicketReference });

      model.InvalidTicket = result.InvalidTicket;
      model.InvalidTime = result.InvalidTime;
      TempData.Add(ModelKey, model);

      return RedirectToAction(nameof(AddTicketWorkLogController.Index),
                              new { id = model.TicketReference });
    }

    AddTicketWorkLogModel GetModel(TicketReference ticketRef)
    {
      var model = TempData.TryGet<AddTicketWorkLogModel>(ModelKey) ?? new AddTicketWorkLogModel();
      model.TicketReference = ticketRef;
      return model;
    }
  }
}
