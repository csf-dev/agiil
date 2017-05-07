using System;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Agiil.Web.OAuth
{
  /// <summary>
  /// This is an implementation of <see cref="InMemorySymmetricSecurityKey"/> which explicitly supports the HMAC SHA 256
  /// algorithm.  The current mono implementation does not, and so this is required to work around that limitation.
  /// </summary>
  class MonoCompatibleInMemorySymmetricSecurityKey : InMemorySymmetricSecurityKey
  {
    byte[] key;

    public override KeyedHashAlgorithm GetKeyedHashAlgorithm(string algorithm)
    {
      if(algorithm == SecurityAlgorithms.HmacSha256Signature)
        return new HMACSHA256(key);

      return base.GetKeyedHashAlgorithm(algorithm);
    }

    public MonoCompatibleInMemorySymmetricSecurityKey(byte[] key) : base(key)
    {
      this.key = key;
    }
  }
}
