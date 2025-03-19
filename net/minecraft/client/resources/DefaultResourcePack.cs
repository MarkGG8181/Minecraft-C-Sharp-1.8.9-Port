using System.Drawing;
using System.Reflection;
using Minecraft1_8_9Port.net.minecraft.client.resources.data;
using ResourceLocation = Minecraft1_8_9Port.net.minecraft.util.ResourceLocation;

namespace Minecraft1_8_9Port.net.minecraft.client.resources;

public class DefaultResourcePack : IResourcePack
{
    public static readonly HashSet<string> defaultResourceDomains = new HashSet<string> { "minecraft" };
    private readonly Dictionary<string, FileInfo> mapAssets;

    public DefaultResourcePack(Dictionary<string, FileInfo> mapAssetsIn)
    {
        this.mapAssets = mapAssetsIn;
    }

    public Stream getInputStream(ResourceLocation location)
    {
        Stream inputstream = this.getResourceStream(location);

        if (inputstream != null)
        {
            return inputstream;
        }
        else
        {
            Stream inputstream1 = this.getInputStreamAssets(location);

            if (inputstream1 != null)
            {
                return inputstream1;
            }
            else
            {
                throw new FileNotFoundException(location.getResourcePath());
            }
        }
    }

    public Stream getInputStreamAssets(ResourceLocation location)
    {
        if (this.mapAssets.TryGetValue(location.ToString(), out FileInfo file1) && file1.Exists)
        {
            return new FileStream(file1.FullName, FileMode.Open, FileAccess.Read);
        }

        return null;
    }

    private Stream getResourceStream(ResourceLocation location)
    {
        string resourcePath = "assets." + location.getResourceDomain() + "." + location.getResourcePath();

        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream resourceStream = assembly.GetManifestResourceStream(resourcePath);

        if (resourceStream == null)
        {
            throw new FileNotFoundException("Resource not found: " + resourcePath);
        }

        return resourceStream;
    }

    public bool resourceExists(ResourceLocation location)
    {
        return this.getResourceStream(location) != null || this.mapAssets.ContainsKey(location.ToString());
    }

    public HashSet<string> getResourceDomains()
    {
        return defaultResourceDomains;
    }

    /*
    public T getPackMetadata<T>(IMetadataSerializer metadataSerializer, string metadataSectionName)
        where T : IMetadataSection
    {
        try
        {
            using (Stream inputstream =
                   new FileStream(this.mapAssets["pack.mcmeta"].FullName, FileMode.Open, FileAccess.Read))
            {
                return AbstractResourcePack.readMetadata<T>(metadataSerializer, inputstream, metadataSectionName);
            }
        }
        catch (Exception)
        {
            return default;
        }
    }
    */

    public Bitmap getPackImage()
    {
        string resourcePath = "assets." + new ResourceLocation("pack.png").getResourcePath();

        Assembly assembly = Assembly.GetExecutingAssembly();

        using (Stream resourceStream = assembly.GetManifestResourceStream(resourcePath))
        {
            if (resourceStream == null)
            {
                throw new FileNotFoundException("Resource not found: " + resourcePath);
            }

            return new Bitmap(resourceStream);
        }
    }

    public string getPackName()
    {
        return "Default";
    }
}