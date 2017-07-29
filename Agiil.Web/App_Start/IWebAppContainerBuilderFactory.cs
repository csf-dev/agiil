using System;
using System.Web.Http;
using Agiil.Bootstrap;

namespace Agiil.Web.App_Start
{
  public interface IWebAppContainerBuilderFactory : IAutofacContainerBuilderFactory
  {
    void SetHttpConfiguration(HttpConfiguration config);
  }
}
