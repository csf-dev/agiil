﻿using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class AddCommentSpecification
  {
    public IIdentity<Ticket> TicketId { get; set; }

    public string Body { get; set; }
  }
}
