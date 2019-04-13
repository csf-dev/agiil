using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class AspNetMvcRoutingModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      builder.Register(ctx => RouteTable.Routes);
      builder.Register(ctx => {
        var handler = HttpContext.Current?.Handler as MvcHandler;
        if(handler == null) return null;
        return handler.RequestContext;
      });
      builder.Register(ctx => {
        var requestContext = ctx.ResolveOptional<RequestContext>();
        if(requestContext == null) return null;
        var routeCollection = ctx.Resolve<RouteCollection>();
        return new UrlHelper(requestContext, routeCollection);
      });
		}
	}
}
