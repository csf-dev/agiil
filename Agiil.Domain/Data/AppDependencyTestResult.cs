using System;
namespace Agiil.Domain.Data
{
  public class AppDependencyTestResult
  {
    public bool ConnectionStringIsMissing { get; set; }

    public bool CannotConnectToDatabase { get; set; }

    public bool DatabaseRequiresUpgrade { get; set; }

    public bool IsApplicationOKToUse { get; set; }

    public bool IsApplicationViableForMaintenance { get; set; }
  }
}
