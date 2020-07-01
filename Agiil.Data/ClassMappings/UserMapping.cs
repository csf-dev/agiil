using System;
using Agiil.Data.MappingProviders;
using Agiil.Domain.Auth;
using Agiil.Domain.Projects;
using CSF.Reflection;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ClassMappings
{
    public class UserMapping : IConventionMapping
    {
        internal const string
            Contributor = "Contributor",
            Administrator = "Administrator";

        readonly IDbNameFormatter nameFormatter;

        public void ApplyMapping(ConventionModelMapper mapper)
        {
            mapper.Class<User>(map => {
                map.Set(x => x.ContributorTo, set => {
                    set.Key(key => {
                        key.ForeignKey(nameFormatter.GetForeignKeyConstraintName(Reflect.Property<Project>(x => x.Contributors), typeof(Project)));
                    });
                    set.Table(nameFormatter.GetManyToManyTableName(typeof(Project), Contributor, typeof(User)));
                }, r => r.ManyToMany(mtm => {
                    mtm.ForeignKey(nameFormatter.GetForeignKeyConstraintName(Reflect.Property<User>(x => x.ContributorTo), typeof(User)));
                }));

                map.Set(x => x.AdministratorOf, set => {
                    set.Key(key => {
                        key.ForeignKey(nameFormatter.GetForeignKeyConstraintName(Reflect.Property<Project>(x => x.Administrators), typeof(Project)));
                    });
                    set.Table(nameFormatter.GetManyToManyTableName(typeof(Project), Administrator, typeof(User)));
                }, r => r.ManyToMany(mtm => {
                    mtm.ForeignKey(nameFormatter.GetForeignKeyConstraintName(Reflect.Property<User>(x => x.AdministratorOf), typeof(User)));
                }));
            });
        }

        public UserMapping(IDbNameFormatter nameFormatter)
        {
            this.nameFormatter = nameFormatter ?? throw new ArgumentNullException(nameof(nameFormatter));
        }
    }
}
