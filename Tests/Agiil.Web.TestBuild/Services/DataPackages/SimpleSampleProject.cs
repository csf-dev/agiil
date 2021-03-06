﻿using System;
using System.Linq;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Domain.Labels;
using Agiil.Domain.Projects;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using CSF.ORM;

namespace Agiil.Web.Services.DataPackages
{
    public class SimpleSampleProject : IDataPackage
    {
        readonly IEntityData repo;
        readonly IGetsTransaction transactionCreator;
        readonly IGetsUserByUsername userQuery;
        readonly IUserCreator userCreator;

        public void Load()
        {
            using(var tran = transactionCreator.GetTransaction())
            {
                var project = repo.Query<Project>().First();
                var admin = userQuery.Get(AdminUser.Username);
                admin.SiteAdministrator = true;

                var youssef = CreateYoussef();
                project.Administrators.Add(youssef);

                var sprint1 = CreateSprintOne(project);
                var sprint2 = CreateSprintTwo(project);
                var sprint3 = CreateSprintThree(project);

                var bug = CreateBugType();
                var enhancement = CreateEnhancementType();

                var ticket1 = CreateTicketOne(sprint1, youssef, enhancement);
                var ticket2 = CreateTicketTwo(sprint1, youssef, enhancement);
                var ticket3 = CreateTicketThree(sprint1, youssef, enhancement);
                var ticket4 = CreateClosedTicketFour(sprint1, youssef, bug);
                var ticket5 = CreateTicketFive(sprint2, youssef, bug);
                var ticket6 = CreateTicketSix(sprint2, youssef, bug);

                project.NextAvailableTicketNumber = 7;

                var comment1 = CreateCommentOne(ticket1, youssef);
                var comment2 = CreateCommentTwo(ticket2, admin);
                var comment3 = CreateCommentThree(ticket2, admin);
                var comment4 = CreateCommentFour(ticket2, admin);

                CreateExistingLabelOne(ticket2, ticket3, ticket4);
                CreateExistingLabelTwo(ticket6);

                tran.Commit();
            }
        }

        User CreateYoussef()
        {
            userCreator.Add("Youssef", "secret");
            return userQuery.Get("Youssef");
        }

        TicketType CreateBugType() => new TicketType { Name = "Bug" };

        TicketType CreateEnhancementType() => new TicketType { Name = "Enhancement" };

        Sprint CreateSprintOne(Project project)
        {
            var sprint = new Sprint {
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
            var sprint = new Sprint {
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
            var sprint = new Sprint {
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

        Ticket CreateTicketOne(Sprint sprint, User user, TicketType type)
        {
            var ticket = new Ticket {
                Title = "Sample ticket 1",
                TicketNumber = 1,
                Description = "This ticket has a description",
                CreationTimestamp = new DateTime(2011, 1, 4),
                Project = sprint.Project,
                User = user,
                Type = type,
            };

            sprint.Tickets.Add(ticket);

            repo.Add(ticket);

            return ticket;
        }

        Ticket CreateTicketTwo(Sprint sprint, User user, TicketType type)
        {
            var ticket = new Ticket {
                Title = "Sample ticket 2",
                TicketNumber = 2,
                Description = "This ticket has a description",
                CreationTimestamp = new DateTime(2011, 1, 1),
                Project = sprint.Project,
                User = user,
                Type = type,
            };

            sprint.Tickets.Add(ticket);

            repo.Add(ticket);

            return ticket;
        }

        Ticket CreateTicketThree(Sprint sprint, User user, TicketType type)
        {
            var ticket = new Ticket {
                Title = "Sample ticket 3",
                TicketNumber = 3,
                Description = "This ticket has a description",
                CreationTimestamp = new DateTime(2011, 1, 6),
                Project = sprint.Project,
                User = user,
                Type = type,
            };

            sprint.Tickets.Add(ticket);

            repo.Add(ticket);

            return ticket;
        }

        Ticket CreateClosedTicketFour(Sprint sprint, User user, TicketType type)
        {
            var ticket = new Ticket {
                Title = "Sample ticket 4",
                TicketNumber = 4,
                Description = "This ticket is marked as closed",
                CreationTimestamp = new DateTime(2011, 1, 8),
                Closed = true,
                Project = sprint.Project,
                User = user,
                Type = type,
            };

            sprint.Tickets.Add(ticket);

            repo.Add(ticket);

            return ticket;
        }

        Ticket CreateTicketFive(Sprint sprint, User user, TicketType type)
        {
            var ticket = new Ticket {
                Title = "Sample ticket 5",
                TicketNumber = 5,
                Description = "This ticket has a description",
                CreationTimestamp = new DateTime(2011, 1, 6),
                Project = sprint.Project,
                User = user,
                Type = type,
            };

            sprint.Tickets.Add(ticket);

            repo.Add(ticket);

            return ticket;
        }

        Ticket CreateTicketSix(Sprint sprint, User user, TicketType type)
        {
            var ticket = new Ticket {
                Title = "Sample ticket 6",
                TicketNumber = 6,
                Description = "This ticket has a description",
                CreationTimestamp = new DateTime(2011, 1, 6),
                Project = sprint.Project,
                User = user,
                Type = type,
            };

            sprint.Tickets.Add(ticket);

            repo.Add(ticket);

            return ticket;
        }

        Comment CreateCommentOne(Ticket ticket, User user)
        {
            var comment = new Comment {
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
            var comment = new Comment {
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
            var comment = new Comment {
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
            var comment = new Comment {
                CreationTimestamp = new DateTime(2011, 1, 16),
                LastEditTimestamp = new DateTime(2011, 1, 17),
                User = user,
                Body = "Comment number four",
            };

            ticket.Comments.Add(comment);

            repo.Add(comment);

            return comment;
        }

        Label CreateExistingLabelOne(params Ticket[] tickets)
        {
            var label = new Label { Name = "existing label one" };
            label.Tickets.UnionWith(tickets);

            repo.Add(label);

            return label;
        }

        Label CreateExistingLabelTwo(params Ticket[] tickets)
        {
            var label = new Label { Name = "existing label two" };
            label.Tickets.UnionWith(tickets);

            repo.Add(label);

            return label;
        }

        public SimpleSampleProject(IEntityData repo,
                                   IGetsTransaction transactionCreator,
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
