using System;
namespace Agiil.Domain.Labels
{
  public class LabelFactory : ICreatesLabel
  {
    public Label CreateLabel(string name)
    {
      if(String.IsNullOrEmpty(name))
        throw new ArgumentException("Name must not be null or empty.", nameof(name));
      
      return new Label { Name = name };
    }
  }
}
