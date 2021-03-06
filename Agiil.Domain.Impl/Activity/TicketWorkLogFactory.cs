﻿using System;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Activity
{
    public class TicketWorkLogFactory : IGetsTicketWorkLog
    {
        readonly IParsesTimespan timespanParser;
        readonly IGetsTicketByReference ticketProvider;

        public GetWorklogResponse GetWorkLog(AddWorkLogRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));
            if(request.User == null)
                throw new ArgumentException("User must not be null", nameof(request));

            TimeSpan time;

            try
            {
                time = timespanParser.GetTimeSpan(request.TimeSpent);
            }
            catch(FormatException)
            {
                return new GetWorklogResponse { Success = false, TimeSpentIsInvalid = true, };
            }

            var ticket = ticketProvider.GetTicketByReference(request.TicketReference);
            if(ticket == null)
                return new GetWorklogResponse { Success = false, TicketNotFound = true, };

            var worklog = new TicketWorkLog {
                User = request.User,
                TimeStarted = request.TimeStarted,
            };
            worklog.SetTimeSpent(time);

            return new GetWorklogResponse {
                Success = true,
                Ticket = ticket,
                WorkLog = worklog,
            };
        }

        public TicketWorkLogFactory(IParsesTimespan timespanParser, IGetsTicketByReference ticketProvider)
        {
            if(ticketProvider == null)
                throw new ArgumentNullException(nameof(ticketProvider));
            if(timespanParser == null)
                throw new ArgumentNullException(nameof(timespanParser));
            this.timespanParser = timespanParser;
            this.ticketProvider = ticketProvider;
        }
    }
}
