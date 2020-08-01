using System;
using System.Web.Http;
using Agiil.Auth;
using Agiil.Web.Models.Auth;
using AutoMapper;

namespace Agiil.Web.ApiControllers
{
    public class ChangePasswordController : ApiController
    {
        readonly Lazy<IPasswordChanger> passwordChanger;
        readonly IMapper mapper;

        public ChangePasswordResult Post(ChangePasswordSpecification spec)
        {
            if(spec == null)
                throw new ArgumentNullException(nameof(spec));

            var request = mapper.Map<PasswordChangeRequest>(spec);
            var result = passwordChanger.Value.ChangeOwnPassword(request);
            return mapper.Map<ChangePasswordResult>(result);
        }

        public ChangePasswordController(Lazy<IPasswordChanger> passwordChanger,
                                        IMapper mapper)
        {
            this.passwordChanger = passwordChanger ?? throw new ArgumentNullException(nameof(passwordChanger));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
