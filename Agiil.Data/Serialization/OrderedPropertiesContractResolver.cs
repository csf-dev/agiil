using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Agiil.Data.Serialization
{
  public class OrderedPropertiesContractResolver : DefaultContractResolver
  {
    protected override IList<JsonProperty> CreateProperties(Type type,
                                                            MemberSerialization memberSerialization)
    {
      var props = base.CreateProperties(type, memberSerialization);
      return props
        .OrderBy(p => p.PropertyName)
        .ToList();
    }
  }
}
