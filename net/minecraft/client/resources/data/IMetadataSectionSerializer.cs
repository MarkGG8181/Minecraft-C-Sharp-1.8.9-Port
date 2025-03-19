using Newtonsoft.Json;

namespace Minecraft1_8_9Port.net.minecraft.client.resources.data;

public abstract class IMetadataSectionSerializer<T> : JsonConverter<T> where T : IMetadataSection
{
    public abstract string getSectionName();
}