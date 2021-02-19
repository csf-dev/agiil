using System.Web.Mvc;
using ZptSharp;
using ZptSharp.Mvc5;

namespace Agiil.Web.App_Start
{
    public class MvcViewConfiguration
    {
        public void RegisterViewEngines(ViewEngineCollection engines)
        {
            var viewEngine = new ZptSharpViewEngine(builder => {
                builder
                    .AddHapZptDocuments()
                    .AddStandardZptExpressions()
                    .AddZptCSharpExpressions()
                    .AddZptPipeExpressions();
            });
            engines.Clear();
            engines.Add(viewEngine);
        }
    }
}
