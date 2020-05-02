using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Warframe
{
    class JsonStringEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var nullableType = typeof(Nullable<>);

            if (objectType.GetGenericTypeDefinition().Equals(nullableType))
                objectType = objectType.GenericTypeArguments[0];

            var str = (string) reader.Value;
            str = str.Replace(" ", "");
            if (str.Length > 0 && !Char.IsUpper(str[0]))
                str = str[0].ToString().ToUpper() + str.Substring(1);
            str = str.Trim();

            if (string.IsNullOrEmpty(str))
                return null;

            return Enum.Parse(objectType, str, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
