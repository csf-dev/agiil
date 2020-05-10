using System;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Domain.Projects;
using CSF.ORM;

namespace Agiil.Domain.Data
{
  public class DevelopmentInitialDataCreator : IInitialDataCreator
  {
    readonly IUserCreator userCreator;
    readonly IGetsTransaction transactionCreator;
    readonly IEntityData data;

    public void Create()
    {
      using(var tran = transactionCreator.GetTransaction())
      {
        CreateInitialUser();
        CreateInitialProject();

        tran.Commit();
      }
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

      data.Add(project);
    }

    public DevelopmentInitialDataCreator(IUserCreator userCreator,
                                         IGetsTransaction transactionCreator,
                                         IEntityData projectRepo)
    {
      if(projectRepo == null)
        throw new ArgumentNullException(nameof(projectRepo));
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(userCreator == null)
        throw new ArgumentNullException(nameof(userCreator));

      this.userCreator = userCreator;
      this.data = projectRepo;
      this.transactionCreator = transactionCreator;
    }
  }
}
