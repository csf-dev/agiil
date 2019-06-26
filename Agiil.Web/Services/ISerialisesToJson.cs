using System;
namespace Agiil.Web.Services
{
  public interface ISerialisesToJson
  {
    string Serialize(object obj);
  }
}
