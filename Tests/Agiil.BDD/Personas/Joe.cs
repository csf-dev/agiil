using System;
using CSF.Screenplay.Actors;

namespace Agiil.BDD.Personas
{
  /// <summary>
  /// Joe is a persona representing an anonymous user.  They don't neccesarily have a user account unless
  /// granted one specifically and they most certainly aren't signed in.
  /// </summary>
  public class Joe : IPersona
  {
    public string Name => "Joe";
  }
}
