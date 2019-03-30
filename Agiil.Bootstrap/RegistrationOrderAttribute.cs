using System;
namespace Agiil.Bootstrap
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class RegistrationOrderAttribute : Attribute
  {
    public int RegistrationPass { get; private set; }

    public RegistrationOrderAttribute(int registrationPass)
    {
      if(registrationPass < 1)
        throw new ArgumentOutOfRangeException(nameof(registrationPass), "Registration pass must not be less than one.");

      RegistrationPass = registrationPass;
    }
  }
}
