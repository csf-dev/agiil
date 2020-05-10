using System;
namespace Agiil.Domain.Tickets
{
    public sealed class TicketReference : IEquatable<TicketReference>
    {
        public string ProjectCode { get; private set; }

        public long TicketNumber { get; private set; }

        public bool Equals(TicketReference other)
        {
            if(ReferenceEquals(other, null)) return false;
            if(ReferenceEquals(other, this)) return true;

            return other.ProjectCode == ProjectCode
                   && other.TicketNumber == TicketNumber;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TicketReference);
        }

        public override int GetHashCode()
        {
            return (ProjectCode?.GetHashCode()).GetValueOrDefault() ^ TicketNumber.GetHashCode();
        }

        public override string ToString() => ToString(false);

        public string ToString(bool includeHash) => $"{(includeHash ? "#" : String.Empty)}{ProjectCode}{TicketNumber}";

        public TicketReference() : this(null, 0) { }

        public TicketReference(string projectCode, long ticketNumber)
        {
            ProjectCode = String.IsNullOrEmpty(projectCode) ? null : projectCode;
            TicketNumber = ticketNumber;
        }
    }
}
