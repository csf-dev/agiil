using System;
using CSF.Screenplay.Actors;

namespace Agiil.BDD.Personas
{
  /// <summary>
  /// Youssef is a standard user of the application.  He has a user account and a password, and is permitted to log
  /// in.  He can do things which normal users can do.
  /// </summary>
  public class Youssef : IPersona
  {
    public string Name => Username;

    public static string Username => "Youssef";

    public static string Password => "CorrectHorseBatteryStaple1";
  }
}
