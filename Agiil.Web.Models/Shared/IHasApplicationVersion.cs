using System;
namespace Agiil.Web.Models.Shared
{
  public interface IHasApplicationVersion
  {
    ApplicationVersionInfo ApplicationVersion { get; set; }
  }
}
