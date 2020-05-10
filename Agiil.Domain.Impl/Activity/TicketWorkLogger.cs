using System;
using CSF.ORM;
using CSF.Entities;

namespace Agiil.Domain.Activity
{
  public class TicketWorkLogger : IAddsWorkLogForTicket
  {
    readonly IGetsTicketWorkLog workLogProvider;
    readonly IGetsTransaction transactionFactory;

    public TicketWorkLogger(IGetsTicketWorkLog workLogProvider, IGetsTransaction transactionFactory)
    {
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(workLogProvider == null)
        throw new ArgumentNullException(nameof(workLogProvider));
      
      this.workLogProvider = workLogProvider;
      this.transactionFactory = transactionFactory;
    }

    public AddWorklogResponse AddWorkLog(AddWorkLogRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));

      using(var transaction = transactionFactory.GetTransaction())
      {
        var getWorklogResponse = workLogProvider.GetWorkLog(request);
        if(getWorklogResponse?.Success != true)
        {
          transaction.Rollback();
          return GetFailureResponse(getWorklogResponse);
        }

        getWorklogResponse.Ticket.WorkLogs.Add(getWorklogResponse.WorkLog);
        transaction.Commit();

        return new AddWorklogResponse {
          Success = true,
          TicketId = getWorklogResponse.Ticket.GetIdentity(),
        };
      }
    }

    AddWorklogResponse GetFailureResponse(GetWorklogResponse getWorklogResponse)
    {
      return new AddWorklogResponse {
        Success = false,
        InvalidTicket = getWorklogResponse.TicketNotFound,
        InvalidTime = getWorklogResponse.TimeSpentIsInvalid
      };
    }
  }
}
