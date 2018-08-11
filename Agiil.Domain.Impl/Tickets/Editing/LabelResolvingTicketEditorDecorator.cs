using System;
using Agiil.Domain.Labels;
using CSF.Collections;

namespace Agiil.Domain.Tickets.Editing
{
  public class LabelResolvingTicketEditorDecorator : IEditsTicket
  {
    readonly IEditsTicket wrappedInstance;
    readonly IGetsLabels labelProvider;

    public void Edit(Ticket ticket, EditTicketRequest request)
    {
      wrappedInstance.Edit(ticket, request);

      var labels = labelProvider.GetLabels(request.CommaSeparatedLabelNames);
      ticket.Labels.ReplaceContents(labels);
    }

    public LabelResolvingTicketEditorDecorator(IEditsTicket wrappedInstance, IGetsLabels labelProvider)
    {
      if(labelProvider == null)
        throw new ArgumentNullException(nameof(labelProvider));
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      this.wrappedInstance = wrappedInstance;
      this.labelProvider = labelProvider;
    }
  }
}
