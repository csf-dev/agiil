using System;
namespace Agiil.Domain.Labels
{
  public interface IGetsExistingLabel
  {
    Label GetLabel(string name);
  }
}
