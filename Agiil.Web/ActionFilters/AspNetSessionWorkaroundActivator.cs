using System;
using System.Web.Mvc;

namespace Agiil.Web.ActionFilters
{
  /// <summary>
  /// This action filter works around bugs found in ASP.NET MVC (particularly problematic when combined with OWIN) which
  /// cause the cookie authentication mechanism to fail.
  /// </summary>
  /// <remarks>
  /// <para>
  /// The issue itself has been described as #AG66 on the Agiil issue tracker, but the same symptom is documented
  /// here in this StackOverflow question:
  /// https://stackoverflow.com/questions/20737578/asp-net-sessionid-owin-cookies-do-not-send-to-browser
  /// and also the corresponding answer: https://stackoverflow.com/a/21234614/6221779
  /// </para>
  /// <para>
  /// In short, we must make some kind of use of the ASP.NET session as soon as possible (before the user has
  /// logged in) or else any time we later use the session (such as for TempData), we risk the user having their
  /// OWIN application cookie deleted by the server.  When this occurs, the result is that the user is effectively
  /// logged-out unexpectedly, and dumped back at the login screen.
  /// </para>
  /// <para>
  /// In order to accomplish the above, this action filter uses <c>OnActionExecuting</c> to push a value into the
  /// HTTP session state.  This is sure to happen before any controller action has processed (in any given
  /// cookie-based session).  In turn that means that the user cannot have possibly logged in yet.
  /// By ensuring that a value has been put into the session before OWIN sends an activation cookie, we ensure
  /// that we don't trigger the bug described in the SO question.
  /// </para>
  /// </remarks>
  public class AspNetSessionWorkaroundActivator : IActionFilter
  {
    const string SessionKey = nameof(AspNetSessionWorkaroundActivator);
    static readonly object SessionValue = new object();

    public void OnActionExecuted(ActionExecutedContext filterContext) { /* Intentional no-op */ }

    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
      if(filterContext?.HttpContext?.Session == null) return;
      filterContext.HttpContext.Session[SessionKey] = SessionValue;
    }
  }
}
