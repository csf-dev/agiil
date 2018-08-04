using System;
using Agiil.Domain.Labels;

namespace Agiil.Domain.Tickets.Creation
{
  public class LabelPopulatingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly IGetsLabels labelProvider;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      var ticket = wrappedInstance.CreateTicket(request);

      var labels = labelProvider.GetLabels(request.CommaSeparatedLabelNames);
      ticket.Labels.UnionWith(labels);

      return ticket;
    }

    public LabelPopulatingTicketFactoryDecorator(ICreatesTicket wrappedInstance, IGetsLabels labelProvider)
    {
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      if(labelProvider == null)
        throw new ArgumentNullException(nameof(labelProvider));

      this.wrappedInstance = wrappedInstance;
      this.labelProvider = labelProvider;
    }
  }
}
