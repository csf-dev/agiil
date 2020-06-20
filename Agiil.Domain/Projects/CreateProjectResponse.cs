using System;
using CSF.Entities;
using CSF.Validation;

namespace Agiil.Domain.Projects
{
    public class CreateProjectResponse
    {
        public IIdentity<Project> ProjectIdentity { get; set; }

        public IValidationResult ValidationResult { get; set; }
    }
}
