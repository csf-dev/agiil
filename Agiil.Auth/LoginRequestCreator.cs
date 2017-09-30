using System;
namespace Agiil.Auth
{
  public delegate ILoginRequest LoginRequestCreator(string username, string password, string sourceAddress);
}