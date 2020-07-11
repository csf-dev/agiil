using System;
using Agiil.Domain.Projects;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
    public class ListSprintsRequest
    {
        public bool ShowOpenSprints { get; set; }

        public bool ShowClosedSprints { get; set; }

        /// <summary>
        /// Gets the identity of a project for which to show sprints.
        /// If omitted then "the current project" will be used: <seealso cref="IGetsCurrentProject"/>.
        /// </summary>
        /// <value>The project identity.</value>
        public IIdentity<Project> Project { get; set; }

        public ListSprintsRequest()
        {
            ShowOpenSprints = true;
            ShowClosedSprints = false;
        }
    }
}
