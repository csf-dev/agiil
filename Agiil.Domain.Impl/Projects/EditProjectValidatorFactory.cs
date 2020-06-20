using System;
using Agiil.Domain.Validation;
using CSF.Validation;
using CSF.Validation.Manifest.Fluent;
using CSF.Validation.StockRules;

namespace Agiil.Domain.Projects
{
    public class EditProjectValidatorFactory : ValidatorFactoryBase<EditProjectRequest>
    {
        protected override void ConfigureManifest(IManifestBuilder<EditProjectRequest> builder)
        {
            builder.AddMemberRule<EntityMustExistRule<Project>>(x => x.Identity);

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

            builder.AddRule<ProjectCodeMustBeUniqueExceptForSelfRule>(r => r.Name("UniqueCode"));
        }

        public EditProjectValidatorFactory(IValidatorFactory fac) : base(fac) { }
    }
}
