
using System;
using Agiil.Domain.Labels.Specs;

namespace Agiil.Bootstrap.Labels
{
  public class LabelSpecsModule : NamespaceModule
  {
    protected override string Namespace => typeof(LabelNameIn).Namespace;
  }
}
