using System;
using System.Web.Mvc;
using Agiil.Auth;
using Agiil.Web.Models.Auth;
using AutoMapper;

namespace Agiil.Web.Controllers
{
    public class ChangePasswordController : Controller
    {
        const string ResultKey = "Change password result";

        readonly Lazy<IPasswordChanger> passwordChanger;
        readonly IMapper mapper;

        [HttpGet]
        public ActionResult Index()
        {
            var model = new ChangePasswordModel {
                Result = TempData.TryGet<ChangePasswordResult>(ResultKey),
            };

            if(model.Result?.Success == true)
                return View("Success", model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Change(ChangePasswordSpecification spec)
        {
            if(spec == null)
                throw new ArgumentNullException(nameof(spec));

            var request = mapper.Map<PasswordChangeRequest>(spec);
            var result = passwordChanger.Value.ChangeOwnPassword(request);
            var webResult = mapper.Map<ChangePasswordResult>(result);

            TempData.Clear();

            TempData.Add(ResultKey, webResult);
            return RedirectToAction(nameof(Index));
        }

        public ChangePasswordController(Lazy<IPasswordChanger> passwordChanger,
                                        IMapper mapper)
        {
            this.passwordChanger = passwordChanger ?? throw new ArgumentNullException(nameof(passwordChanger));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
