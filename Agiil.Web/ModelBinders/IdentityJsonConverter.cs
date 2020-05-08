using System;
using Agiil.Web.App_Start;
using CSF.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Agiil.Web.ModelBinders
{
    public class IdentityJsonConverter : JsonConverter
    {
        static readonly IParsesIdentity parser = new IdentityParser();

        public override bool CanConvert(Type objectType)
          => WebApiModelBindingRules.IsIdentityType(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value?.ToString();
            if(value == null) return null;

            var entityType = WebApiModelBindingRules.GetEntityType(objectType);

            return parser.Parse(entityType, value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var identity = value as IIdentity;
            if(identity == null)
            {
                writer.WriteNull();
                return;
            }

            var token = JToken.FromObject(identity.Value);
            token.WriteTo(writer);
        }
    }
}
