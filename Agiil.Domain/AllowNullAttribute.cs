using System;
namespace Agiil.Domain
{
  /// <summary>
  /// Attrinbute indicates that an entity property is permitted to be <c>null</c> in the data model.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public class AllowNullAttribute : Attribute {}
}
