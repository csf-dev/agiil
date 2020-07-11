using System;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    public class CurrentProjectSetter : ISetsCurrentProject
    {
        readonly IAppSessionStore session;

        public void SetCurrentProject([RequireCapability(ProjectCapability.View)] IIdentity<Project> projectId)
        {
            if(projectId == null)
                throw new ArgumentNullException(nameof(projectId));

            session.Set(SessionKey.CurrentProjectIdentity, projectId);
        }

        public CurrentProjectSetter(IAppSessionStore session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }
    }
}
