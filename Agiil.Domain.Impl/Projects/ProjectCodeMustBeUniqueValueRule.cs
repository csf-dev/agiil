using System;
using System.Linq;
using CSF.ORM;
using CSF.Validation.Rules;

namespace Agiil.Domain.Projects
{
    public class ProjectCodeMustBeUniqueValueRule : ValueRule<string>
    {
        readonly IEntityData data;

        protected override RuleOutcome GetValueOutcome(string value)
        {
            if(String.IsNullOrEmpty(value)) return RuleOutcome.Success;

            var hasDuplicateProjectCode = data.Query<Project>()
                .Any(x => x.Code == value);

            return hasDuplicateProjectCode ? RuleOutcome.Failure : RuleOutcome.Success;
        }

        public ProjectCodeMustBeUniqueValueRule(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
