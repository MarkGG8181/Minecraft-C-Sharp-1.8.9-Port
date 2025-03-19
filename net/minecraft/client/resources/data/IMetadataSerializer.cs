using Minecraft1_8_9Port.net.minecraft.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minecraft1_8_9Port.net.minecraft.client.resources.data;

public class IMetadataSerializer
{
    private readonly Dictionary<string, Registration> metadataSectionSerializerRegistry = new Dictionary<string, Registration>();
    private JsonSerializerSettings jsonSerializerSettings;
    private JsonSerializer jsonSerializer;
    
    public IMetadataSerializer()
    {
        // Register type adapters for custom serialization
        this.jsonSerializerSettings.Converters.Add(new IChatComponent.Serializer());
        this.jsonSerializerSettings.Converters.Add(new ChatStyle.Serializer());
    }
    
    public void registerMetadataSectionType<T>(IMetadataSectionSerializer<T> metadataSectionSerializer, Type clazz) where T : IMetadataSection
    {
        // Register the section name and serializer in the dictionary
        this.metadataSectionSerializerRegistry[metadataSectionSerializer.getSectionName()] = new Registration<T>(metadataSectionSerializer, clazz);

        // Register type adapter (if necessary)
        JsonConvert.DefaultSettings = () => jsonSerializerSettings;

        // Reset the JSON serializer if needed
        this.jsonSerializer = null;
    }
    
    public T parseMetadataSection<T>(string sectionName, JObject json) where T : IMetadataSection
        {
            if (sectionName == null)
            {
                throw new ArgumentException("Metadata section name cannot be null");
            }
            else if (!json.ContainsKey(sectionName))
            {
                return default; // Return null if section is not found
            }
            else if (json[sectionName].Type != JTokenType.Object)
            {
                throw new ArgumentException($"Invalid metadata for '{sectionName}' - expected object, found {json[sectionName]}");
            }
            else
            {
                var registration = this.metadataSectionSerializerRegistry.getObject(sectionName);
    
                if (registration == null)
                {
                    throw new ArgumentException($"Don't know how to handle metadata section '{sectionName}'");
                }
                else
                {
                    return (T)this.getJsonSerializer().Deserialize(json[sectionName].CreateReader(), registration.clazz);
                }
            }
        }
        
    private JsonSerializer getJsonSerializer()
    {
        if (this.jsonSerializer == null)
        {
            this.jsonSerializer = JsonSerializer.Create(jsonSerializerSettings);
        }

        return this.jsonSerializer;
    }

    public class Registration<T> where T : IMetadataSection
    {
        public IMetadataSectionSerializer<T> Section { get; }
        public Type Clazz { get; }

        public Registration(IMetadataSectionSerializer<T> section, Type clazz)
        {
            this.Section = section;
            this.Clazz = clazz;
        }
    }
}