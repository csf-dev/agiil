using System;
using System.Web.Http;
using Agiil.Bootstrap;

namespace Agiil.Web.App_Start
{
    public interface IGetsAutofacContainerWithOverridableHttpConfiguration : IGetsAutofacContainer
    {
        HttpConfiguration HttpConfig { get; set; }
    }
}
