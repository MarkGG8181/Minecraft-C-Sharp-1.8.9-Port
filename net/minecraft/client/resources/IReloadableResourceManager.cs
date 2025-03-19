namespace Minecraft1_8_9Port.net.minecraft.client.resources;

public interface IReloadableResourceManager : IResourceManager
{
    void reloadResources(List<IResourcePack> resourcesPacksList);

    void registerReloadListener(IResourceManagerReloadListener reloadListener);
}