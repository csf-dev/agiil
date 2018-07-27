using System;
namespace Agiil.Domain.TicketSearch
{
  public class ConstantValue : Value, IEquatable<ConstantValue>, IEquatable<Value>
  {
    int? cachedHashCode;

    public string Text { get; set; }

    public override void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }

    public bool Equals(ConstantValue other)
    {
      if(ReferenceEquals(other, null)) return false;
      return other.Text == Text;
    }

    public bool Equals(Value other) => Equals(other as ConstantValue);

    public override bool Equals(object obj) => Equals(obj as ConstantValue);

		public override int GetHashCode()
		{
      if(!cachedHashCode.HasValue)
        cachedHashCode = (Text?.GetHashCode()).GetValueOrDefault();
      
      return cachedHashCode.Value;
		}

		public static ConstantValue FromConstant(string value) => new ConstantValue { Text = value };
	}
}
