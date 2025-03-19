using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minecraft1_8_9Port;

public class PropertyMap : Dictionary<string, List<Property>>
{
    public PropertyMap()
    {
    }

    public new void Add(string key, Property value)
    {
        if (!ContainsKey(key))
        {
            this[key] = new List<Property>();
        }

        this[key].Add(value);
    }

    public class Serializer : JsonConverter<PropertyMap>
    {
        public override PropertyMap ReadJson(JsonReader reader, Type objectType, PropertyMap existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var result = new PropertyMap();
            var jsonObject = JObject.Load(reader);

            foreach (var property in jsonObject.Properties())
            {
                if (property.Value.Type == JTokenType.Array)
                {
                    foreach (var element in property.Value)
                    {
                        result.Add(property.Name, new Property(property.Name, element.ToString()));
                    }
                }
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, PropertyMap value, JsonSerializer serializer)
        {
            var result = new JArray();

            foreach (var propertyList in value.Values)
            {
                foreach (var property in propertyList)
                {
                    var jsonObject = new JObject
                    {
                        { "name", property.getName() },
                        { "value", property.getValue() }
                    };
                    if (property.hasSignature())
                    {
                        jsonObject.Add("signature", property.getSignature());
                    }

                    result.Add(jsonObject);
                }
            }

            result.WriteTo(writer);
        }
    }
}