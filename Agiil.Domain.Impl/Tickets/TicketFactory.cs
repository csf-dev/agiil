using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Labels;
using Agiil.Domain.Projects;
using Agiil.Domain.Sprints;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketFactory : ITicketFactory
  {
    readonly IEntityData data;
    readonly IEnvironment environment;
    readonly ICurrentProjectGetter projectGetter;
    readonly ICurrentUserReader userReader;
    readonly IGetsLabels labelProvider;

    public Ticket CreateTicketForCurrentUser(CreateTicketRequest request)
      => CreateTicket(request, userReader.RequireCurrentUser());

    public Ticket CreateTicket(CreateTicketRequest request, User creator)
    {
      var project = projectGetter.GetCurrentProject();
      var ticketType = data.Theorise(request.TicketTypeIdentity);
      var timestamp = environment.GetCurrentUtcTimestamp();
      var ticketNumber = (project != null)? project.NextAvailableTicketNumber++ : default(long);

      var ticket = new Ticket
      {
        Title = request.Title,
        Description = request.Description,
        User = creator,
        CreationTimestamp = timestamp,
        Project = project,
        TicketNumber = ticketNumber,
        Type = ticketType,
      };

      PopulateSprint(ticket, request.SprintIdentity);
      PopulateLabels(ticket, request.CommaSeparatedLabelNames);

      return ticket;
    }

    void PopulateSprint(Ticket ticket, IIdentity<Sprint> sprintIdentity)
    {
      if(sprintIdentity != null)
        ticket.Sprint = data.Theorise(sprintIdentity);
    }

    void PopulateLabels(Ticket ticket, string commaSeparatedLabelNames)
    {
      var labels = labelProvider.GetLabels(commaSeparatedLabelNames);
      ticket.Labels.UnionWith(labels);
    }

    public TicketFactory(IEnvironment environment,
                         ICurrentProjectGetter projectGetter,
                         ICurrentUserReader userReader,
                         IEntityData data,
                         IGetsLabels labelProvider)
    {
      if(labelProvider == null)
        throw new ArgumentNullException(nameof(labelProvider));
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(projectGetter == null)
        throw new ArgumentNullException(nameof(projectGetter));
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      
      this.data = data;
      this.userReader = userReader;
      this.environment = environment;
      this.projectGetter = projectGetter;
      this.labelProvider = labelProvider;
    }
  }
}
