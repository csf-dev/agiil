using System;
using Agiil.Auth;

namespace Agiil.Web.Models
{
  public class UsernameUserInfo : ICurrentUserInfo
  {
    public string Username { get; set; }
  }
}
