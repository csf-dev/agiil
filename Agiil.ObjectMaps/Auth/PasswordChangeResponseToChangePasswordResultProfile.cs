using System;
using Agiil.Auth;
using Agiil.Web.Models.Auth;
using AutoMapper;

namespace Agiil.ObjectMaps.Auth
{
    public class PasswordChangeResponseToChangePasswordResultProfile : Profile
    {
        public PasswordChangeResponseToChangePasswordResultProfile()
        {
            CreateMap<PasswordChangeResponse,ChangePasswordResult>();
        }
    }
}
