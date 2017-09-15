using System;
using System.Linq;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Domain.Projects;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Web.Services.DataPackages
{
  public class SimpleSampleProject : IDataPackage
  {
    readonly IEntityData repo;
    readonly ITransactionCreator transactionCreator;
    readonly IGetsUserByUsername userQuery;
    readonly IUserCreator userCreator;

    public void Load()
    {
      using(var tran = transactionCreator.BeginTransaction())
      {
        var project = repo.Query<Project>().First();
        var admin = userQuery.Get(AdminUser.Username);

        var youssef = CreateYoussef();

        var sprint1 = CreateSprintOne(project);
        var sprint2 = CreateSprintTwo(project);
        var sprint3 = CreateSprintThree(project);

        var ticket1 = CreateTicketOne(sprint1, youssef);
        var ticket2 = CreateTicketTwo(sprint1, youssef);
        var ticket3 = CreateTicketThree(sprint1, youssef);

        var comment1 = CreateCommentOne(ticket1, youssef);
        var comment2 = CreateCommentTwo(ticket2, admin);
        var comment3 = CreateCommentThree(ticket2, admin);
        var comment4 = CreateCommentFour(ticket2, admin);

        tran.Commit();
      }
    }

    User CreateYoussef()
    {
      userCreator.Add("Youssef", "secret");
      return userQuery.Get("Youssef");
    }

    Sprint CreateSprintOne(Project project)
    {
      var sprint = new Sprint
      {
        Name = "Sprint one",
        Description = "This is sprint number one",
        CreationDate = new DateTime(2011, 1, 1),
        StartDate = new DateTime(2011, 3, 1),
        EndDate = new DateTime(2011, 4, 1),
      };

      project.Sprints.Add(sprint);
      repo.Add(sprint);

      return sprint;
    }

    Sprint CreateSprintTwo(Project project)
    {
      var sprint = new Sprint
      {
        Name = "Sprint two",
        Description = "This is sprint number two, which is closed",
        CreationDate = new DateTime(2011, 1, 1),
        StartDate = new DateTime(2011, 2, 1),
        EndDate = new DateTime(2011, 3, 1),
        Closed = true,
      };

      project.Sprints.Add(sprint);
      repo.Add(sprint);

      return sprint;
    }

    Sprint CreateSprintThree(Project project)
    {
      var sprint = new Sprint
      {
        Name = "Sprint three",
        Description = "This is sprint number three",
        CreationDate = new DateTime(2011, 1, 2),
        StartDate = new DateTime(2011, 1, 1),
        EndDate = new DateTime(2011, 2, 1),
      };

      project.Sprints.Add(sprint);

      repo.Add(sprint);

      return sprint;
    }

    Ticket CreateTicketOne(Sprint sprint, User user)
    {
      var ticket = new Ticket
      {
        Title = "Sample ticket 1",
        TicketNumber = 1,
        Description = "This ticket has a description",
        CreationTimestamp = new DateTime(2011, 1, 4),
        Project = sprint.Project,
        User = user,
      };

      sprint.Tickets.Add(ticket);

      repo.Add(ticket);

      return ticket;
    }

    Ticket CreateTicketTwo(Sprint sprint, User user)
    {
      var ticket = new Ticket
      {
        Title = "Sample ticket 2",
        TicketNumber = 2,
        Description = "This ticket has a description",
        CreationTimestamp = new DateTime(2011, 1, 1),
        Project = sprint.Project,
        User = user,
      };

      sprint.Tickets.Add(ticket);

      repo.Add(ticket);

      return ticket;
    }

    Ticket CreateTicketThree(Sprint sprint, User user)
    {
      var ticket = new Ticket
      {
        Title = "Sample ticket 3",
        TicketNumber = 3,
        Description = "This ticket has a description",
        CreationTimestamp = new DateTime(2011, 1, 6),
        Project = sprint.Project,
        User = user,
      };

      sprint.Tickets.Add(ticket);

      repo.Add(ticket);

      return ticket;
    }

    Ticket CreateTicketFour(Sprint sprint, User user)
    {
      var ticket = new Ticket
      {
        Title = "Sample ticket 4",
        TicketNumber = 4,
        Description = "This ticket is marked as closed",
        CreationTimestamp = new DateTime(2011, 1, 8),
        Closed = true,
        Project = sprint.Project,
        User = user,
      };

      sprint.Tickets.Add(ticket);

      repo.Add(ticket);

      return ticket;
    }

    Comment CreateCommentOne(Ticket ticket, User user)
    {
      var comment = new Comment
      {
        CreationTimestamp = new DateTime(2011, 1, 10),
        LastEditTimestamp = new DateTime(2011, 1, 10),
        User = user,
        Body = "Comment number one",
      };

      ticket.Comments.Add(comment);

      repo.Add(comment);

      return comment;
    }

    Comment CreateCommentTwo(Ticket ticket, User user)
    {
      var comment = new Comment
      {
        CreationTimestamp = new DateTime(2011, 1, 20),
        LastEditTimestamp = new DateTime(2011, 1, 22),
        User = user,
        Body = "Comment number two",
      };

      ticket.Comments.Add(comment);

      repo.Add(comment);

      return comment;
    }

    Comment CreateCommentThree(Ticket ticket, User user)
    {
      var comment = new Comment
      {
        CreationTimestamp = new DateTime(2011, 1, 15),
        LastEditTimestamp = new DateTime(2011, 1, 25),
        User = user,
        Body = "Comment number three",
      };

      ticket.Comments.Add(comment);

      repo.Add(comment);

      return comment;
    }

    Comment CreateCommentFour(Ticket ticket, User user)
    {
      var comment = new Comment
      {
        CreationTimestamp = new DateTime(2011, 1, 16),
        LastEditTimestamp = new DateTime(2011, 1, 17),
        User = user,
        Body = "Comment number four",
      };

      ticket.Comments.Add(comment);

      repo.Add(comment);

      return comment;
    }

    public SimpleSampleProject(IEntityData repo,
                               ITransactionCreator transactionCreator,
                               IGetsUserByUsername userQuery,
                               IUserCreator userCreator)
    {
      if(userCreator == null)
        throw new ArgumentNullException(nameof(userCreator));
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      if(userQuery == null)
        throw new ArgumentNullException(nameof(userQuery));
      
      this.transactionCreator = transactionCreator;
      this.repo = repo;
      this.userQuery = userQuery;
      this.userCreator = userCreator;
    }
  }
}
