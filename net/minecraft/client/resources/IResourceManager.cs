using Minecraft1_8_9Port.net.minecraft.util;

namespace Minecraft1_8_9Port.net.minecraft.client.resources;

public interface IResourceManager
{
    HashSet<string> getResourceDomains();

    IResource getResource(ResourceLocation location);

    List<IResource> getAllResources(ResourceLocation location);
}