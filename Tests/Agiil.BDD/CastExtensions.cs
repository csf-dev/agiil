using System;
using Agiil.BDD.Personas;
using CSF.Screenplay.Actors;

namespace Agiil.BDD
{
  public static class CastExtensions
  {
    public static IActor Get<TPersona>(this ICast cast) where TPersona : IPersona,new()
    {
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));
      
      var persona = new TPersona();
      return cast.Get(persona.Name);
    }
  }
}
