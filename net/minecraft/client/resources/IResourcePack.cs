using System.Drawing;
using Minecraft1_8_9Port.net.minecraft.client.resources.data;
using Minecraft1_8_9Port.net.minecraft.util;

namespace Minecraft1_8_9Port.net.minecraft.client.resources;

public interface IResourcePack
{
    Stream getInputStream(ResourceLocation location);

    bool resourceExists(ResourceLocation location);

    HashSet<string> getResourceDomains();

    T getPackMetadata<T>(IMetadataSerializer metadataSerializer, string metadataSectionName) where T : IMetadataSection;

    Bitmap getPackImage();

    string getPackName();
}