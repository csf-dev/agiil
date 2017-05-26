using System;
using Agiil.Domain.Projects;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public class ProjectCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<Project>(proj => {
        proj
          .OmitAutoProperties()
          .With(x => x.Name)
          .With(x => x.Code)
          .With(x => x.NextAvailableTicketNumber, 11);

        return proj;
      });
    }
  }
}
