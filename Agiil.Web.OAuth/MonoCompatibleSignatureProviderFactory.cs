using System;
using System.IdentityModel.Tokens;

namespace Agiil.Web.OAuth
{
  class MonoCompatibleSignatureProviderFactory : SignatureProviderFactory
  {
    public override SignatureProvider CreateForVerifying(SecurityKey key, string algorithm)
    {
      if(algorithm == SecurityAlgorithms.HmacSha256Signature && key is InMemorySymmetricSecurityKey)
      {
        var castKey = (InMemorySymmetricSecurityKey) key;
        var copiedKey = new MonoCompatibleInMemorySymmetricSecurityKey(castKey.GetSymmetricKey());
        return new SymmetricSignatureProvider(copiedKey, algorithm);
      }

      return base.CreateForVerifying(key, algorithm);
    }
  }
}
