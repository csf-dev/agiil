﻿using System;
using CSF.Screenplay;

namespace Agiil.BDD.Personas
{
  /// <summary>
  /// April is a persona who can act as the application.  In other words she is more than a root administrator,
  /// she has direct control over the application state (including the database) and can do things which are
  /// impossible via the published UI/API.
  /// </summary>
  public class April : Persona
  {
    public override string Name => "April";
  }
}
