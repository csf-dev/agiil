using System;
using Owin;

namespace CSF.IssueTracker.Web.App_Start
{
  /// <summary>
  /// Implementation of an OWIN startup configuration type.  Must be named <c>Startup</c> and must have a
  /// <c>Configuration</c> method.
  /// </summary>
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      new AuthConfig().Configure(app);
    }
  }
}
