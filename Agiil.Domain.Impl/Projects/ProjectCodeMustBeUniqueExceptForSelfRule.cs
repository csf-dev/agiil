using System;
using System.Linq;
using CSF.ORM;
using CSF.Validation.Rules;

namespace Agiil.Domain.Projects
{
    public class ProjectCodeMustBeUniqueExceptForSelfRule : Rule<EditProjectRequest>
    {
        readonly IEntityData data;

        protected override RuleOutcome GetOutcome(EditProjectRequest validated)
        {
            if(String.IsNullOrEmpty(validated.Code)) return RuleOutcome.Success;
            if(validated.Identity == null) return RuleOutcome.Success;

            var project = data.Theorise(validated.Identity);
            var hasDuplicateCode = data.Query<Project>()
                .Any(x => x != project && x.Code == validated.Code);

            return hasDuplicateCode ? RuleOutcome.Failure : RuleOutcome.Success;
        }

        public ProjectCodeMustBeUniqueExceptForSelfRule(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
