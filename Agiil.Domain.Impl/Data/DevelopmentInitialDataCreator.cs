using System;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Domain.Projects;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Domain.Data
{
  public class DevelopmentInitialDataCreator : IInitialDataCreator
  {
    readonly IUserCreator userCreator;
    readonly ITransactionCreator transactionCreator;
    readonly IEntityData projectRepo;

    public void Create()
    {
      CreateInitialUser();
      CreateInitialProject();
    }

    void CreateInitialUser()
    {
      userCreator.Add(AdminUser.Username, AdminUser.Password);
    }

    void CreateInitialProject()
    {
      var project = new Project
      {
        Name = AgiilProject.Name,
        Code = AgiilProject.Code,
        NextAvailableTicketNumber = 1,
      };

      using(var tran = transactionCreator.BeginTransaction())
      {
        projectRepo.Add(project);
        tran.Commit();
      }
    }

    public DevelopmentInitialDataCreator(IUserCreator userCreator,
                                         ITransactionCreator transactionCreator,
                                         IEntityData projectRepo)
    {
      if(projectRepo == null)
        throw new ArgumentNullException(nameof(projectRepo));
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(userCreator == null)
        throw new ArgumentNullException(nameof(userCreator));

      this.userCreator = userCreator;
      this.projectRepo = projectRepo;
      this.transactionCreator = transactionCreator;
    }
  }
}
