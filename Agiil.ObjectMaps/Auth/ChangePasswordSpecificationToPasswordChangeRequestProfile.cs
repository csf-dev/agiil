using System;
using Agiil.Auth;
using Agiil.Web.Models.Auth;
using AutoMapper;

namespace Agiil.ObjectMaps.Auth
{
    public class ChangePasswordSpecificationToPasswordChangeRequestProfile : Profile
    {
        public ChangePasswordSpecificationToPasswordChangeRequestProfile()
        {
            CreateMap<ChangePasswordSpecification, PasswordChangeRequest>()
               .ForMember(x => x.ConfirmNewPassword, o => o.ResolveUsing(x => x.NewPasswordConfirmation));
        }
    }
}
