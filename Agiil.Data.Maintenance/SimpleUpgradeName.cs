using System;
namespace Agiil.Data.Maintenance
{
  public class SimpleUpgradeName : IUpgradeName
  {
    public string Name { get; set; }

    public string GetName() => Name;
  }
}
