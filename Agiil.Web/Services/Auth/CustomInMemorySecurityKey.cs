using System;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Agiil.Web.Services.Auth
{
  class CustomInMemorySymmetricSecurityKey : InMemorySymmetricSecurityKey
  {
    byte[] key;

    public override KeyedHashAlgorithm GetKeyedHashAlgorithm(string algorithm)
    {
      if(algorithm == SecurityAlgorithms.HmacSha256Signature)
        return new HMACSHA256(key);

      return base.GetKeyedHashAlgorithm(algorithm);
    }

    public CustomInMemorySymmetricSecurityKey(byte[] key) : base(key)
    {
      this.key = key;
    }
  }
}
