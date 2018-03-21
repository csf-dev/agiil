using System;
using Agiil.Domain.Data;

namespace Agiil.Data
{
  public class SimpleUpgradeName : IUpgradeName
  {
    public string Name { get; set; }

    public string GetName() => Name;
  }
}
