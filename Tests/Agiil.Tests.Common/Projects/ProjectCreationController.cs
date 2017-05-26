using System;
using Agiil.Domain.Projects;
using Agiil.Tests.Autofixture;
using CSF.Data.Entities;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Projects
{
  public class ProjectCreationController : IProjectCreationController
  {
    readonly IFixture autoFixture;
    readonly IRepository<Project> repo;

    public void SetupProjectAndMakeCurrent(long id)
    {
      new ProjectCustomization().Customize(autoFixture);
      var project = autoFixture.Create<Project>();
      project.SetIdentityValue(id);

      repo.Add(project);
    }

    public ProjectCreationController(IFixture autoFixture,
                                     IRepository<Project> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      if(autoFixture == null)
        throw new ArgumentNullException(nameof(autoFixture));
      this.autoFixture = autoFixture;
      this.repo = repo;
    }
  }
}
