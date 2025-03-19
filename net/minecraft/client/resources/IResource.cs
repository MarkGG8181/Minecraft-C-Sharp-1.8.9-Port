using Minecraft1_8_9Port.net.minecraft.client.resources.data;
using Minecraft1_8_9Port.net.minecraft.util;

namespace Minecraft1_8_9Port.net.minecraft.client.resources;

public interface IResource
{
    ResourceLocation GetResourceLocation();

    Stream GetInputStream();

    bool HasMetadata();

    T GetMetadata<T>(string p_110526_1_) where T : IMetadataSection;

    string GetResourcePackName();
}