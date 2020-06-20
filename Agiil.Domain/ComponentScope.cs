using System;
namespace Agiil.Domain
{
    [Serializable]
    public class ComponentScope : IEquatable<ComponentScope>
    {
        public string Name { get; }

        public bool Equals(ComponentScope other) => String.Equals(other?.Name, Name, StringComparison.InvariantCulture);

        public override bool Equals(object obj) => Equals(obj as ComponentScope);

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => $"[ComponentScope:'{Name}']";

        ComponentScope(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
