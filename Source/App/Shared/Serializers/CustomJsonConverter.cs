using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Shared.Serializers
{
    public class CustomJsonConverter : ICustomJsonConverter
    {
        private JsonSerializerSettings settings;

        public CustomJsonConverter()
        {
            settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>() { new StringEnumConverter() },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public string Serilize(string message) => JsonConvert.SerializeObject(message, settings);
    }
}
