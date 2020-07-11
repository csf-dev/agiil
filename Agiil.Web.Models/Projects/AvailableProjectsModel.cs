using System;
using System.Collections.Generic;

namespace Agiil.Web.Models.Projects
{
    public class AvailableProjectsModel
    {
        public bool MultipleProjectsAvaialble => Projects?.Count > 1;

        public bool CanCreateSprints { get; set; }

        public IList<AvailableProjectModel> Projects { get; set; }
    }
}
