using System;
namespace Agiil.Domain
{
  public class ComponentScope : IEquatable<ComponentScope>
  {
    #region constants

    const string
      APPLICATION_CONNECTION_SCOPE_NAME = "Application connection";

    #endregion

    #region instance functionality

    public string Name { get; private set; }

    public bool Equals(ComponentScope other)
    {
      return other != null && other.Name == Name;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as ComponentScope);
    }

    public override int GetHashCode()
    {
      return Name.GetHashCode();
    }

    public override string ToString()
    {
      return $"[ComponentScope:'{Name}']";
    }

    #endregion

    #region constructors

    ComponentScope(string name)
    {
      if(name == null)
        throw new ArgumentNullException(nameof(name));

      Name = name;
    }

    static ComponentScope()
    {
      ApplicationConnection = new ComponentScope(APPLICATION_CONNECTION_SCOPE_NAME);
    }

    #endregion

    #region singletons

    public static ComponentScope ApplicationConnection { get; private set; }

    #endregion
  }
}
