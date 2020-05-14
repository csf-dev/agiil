using System;
using Agiil.Domain;
using Agiil.Domain.Projects;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    public class CurrentlyChosenProjectDecorator : IGetsCurrentProject
    {
        readonly IGetsCurrentProject wrapped;
        readonly IAppSessionStore session;
        readonly IEntityData data;

        public Project GetCurrentProject()
        {
            if(session.TryGet(SessionKey.CurrentProjectIdentity, out IIdentity<Project> id))
                return data.Get(id);

            var project = wrapped.GetCurrentProject();
            if(project != null)
                session.Set(SessionKey.CurrentProjectIdentity, project.GetIdentity());

            return project;
        }

        public CurrentlyChosenProjectDecorator(IGetsCurrentProject wrapped,
                                               IAppSessionStore session,
                                               IEntityData data)
        {
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
            this.session = session ?? throw new ArgumentNullException(nameof(session));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
