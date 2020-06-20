using System;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Projects
{
    public class CreateProjectValidatorFactory : ValidatorFactoryBase<CreateProjectRequest>
    {
        protected override void ConfigureManifest(IManifestBuilder<CreateProjectRequest> builder)
        {
            builder.AddMemberRule<NotNullValueRule>(x => x.Name);
            builder.AddMemberRule<StringLengthValueRule>(x => x.Name, r => {
                r.Configure(c => c.MinLength = 1);
            });

            builder.AddMemberRule<NotNullValueRule>(x => x.Code);
            builder.AddMemberRule<StringLengthValueRule>(x => x.Code, r => {
                r.Configure(c => {
                    c.MinLength = Project.MinCodeLength;
                    c.MaxLength = Project.MaxCodeLength;
                });
            });
            builder.AddMemberRule<ProjectCodeMustBeUniqueValueRule>(x => x.Code);
        }

        public CreateProjectValidatorFactory(IValidatorFactory fac) : base(fac) { }
    }
}
