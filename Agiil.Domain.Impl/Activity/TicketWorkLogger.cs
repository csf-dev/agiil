using System;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Domain.Activity
{
  public class TicketWorkLogger : IAddsWorkLogForTicket
  {
    readonly IGetsTicketWorkLog workLogProvider;
    readonly ITransactionCreator transactionFactory;
    readonly IEntityData data;

    public TicketWorkLogger(IGetsTicketWorkLog workLogProvider, ITransactionCreator transactionFactory, IEntityData data)
    {
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(workLogProvider == null)
        throw new ArgumentNullException(nameof(workLogProvider));
      
      this.workLogProvider = workLogProvider;
      this.transactionFactory = transactionFactory;
      this.data = data;
    }

    public AddWorklogResponse AddWorkLog(AddWorkLogRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));

      using(var transaction = transactionFactory.BeginTransaction())
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
