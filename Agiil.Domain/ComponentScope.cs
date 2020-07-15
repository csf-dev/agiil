using System;
using System.Runtime.Serialization;

namespace Agiil.Domain
{
    [Serializable]
    public class ComponentScope : IEquatable<ComponentScope>, ISerializable
    {
        public string Name { get; }

        public bool Equals(ComponentScope other) => String.Equals(other?.Name, Name, StringComparison.InvariantCulture);

        public override bool Equals(object obj) => Equals(obj as ComponentScope);

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => $"[ComponentScope:'{Name}']";

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Name), Name);
        }

        ComponentScope(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        protected ComponentScope(SerializationInfo info, StreamingContext context)
        {
            Name = (string) info.GetValue(nameof(Name), typeof(string));
            if(Name == null)
                throw new SerializationException("The name must not be null.");
        }
    }
}
