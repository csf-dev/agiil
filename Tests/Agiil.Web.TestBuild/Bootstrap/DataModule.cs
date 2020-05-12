using System;
namespace Agiil.Web.Bootstrap
{
    // We want all of the same functionality as that other module (in a different assembly)
    // but we don't want to scan that assembly for all modules.
    public class DataModule : Agiil.Tests.Bootstrap.DataModule { }
}
