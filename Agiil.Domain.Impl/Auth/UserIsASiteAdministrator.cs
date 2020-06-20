using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Auth
{
    public interface ISpecificationForSiteAdministrators : ISpecificationExpression<User> { }

    public class UserIsASiteAdministrator : ISpecificationForSiteAdministrators
    {
        public Expression<Func<User, bool>> GetExpression() => x => x.SiteAdministrator;
    }
}
