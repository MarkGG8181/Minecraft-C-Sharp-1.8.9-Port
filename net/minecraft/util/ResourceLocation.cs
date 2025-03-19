namespace Minecraft1_8_9Port.net.minecraft.util;

public class ResourceLocation
{
    protected readonly string ResourceDomain;
    protected readonly string ResourcePath;

    protected ResourceLocation(int identifier, params string[] resourceName)
    {
        ResourceDomain = string.IsNullOrEmpty(resourceName[0]) ? "minecraft" : resourceName[0].ToLower();
        ResourcePath = resourceName[1];
        if (ResourcePath == null) throw new ArgumentNullException(nameof(ResourcePath));
    }

    public ResourceLocation(string resourceName)
        : this(0, splitObjectName(resourceName))
    {
    }

    public ResourceLocation(string resourceDomainIn, string resourcePathIn)
        : this(0, resourceDomainIn, resourcePathIn)
    {
    }

    protected static string[] splitObjectName(string toSplit)
    {
        string[] resultArray = new string[] { null, toSplit };
        int index = toSplit.IndexOf(':');

        if (index >= 0)
        {
            resultArray[1] = toSplit.Substring(index + 1);

            if (index > 1)
            {
                resultArray[0] = toSplit.Substring(0, index);
            }
        }

        return resultArray;
    }

    public string getResourcePath()
    {
        return ResourcePath;
    }

    public string getResourceDomain()
    {
        return ResourceDomain;
    }

    public override string ToString()
    {
        return $"{ResourceDomain}:{ResourcePath}";
    }

    public override bool Equals(object obj)
    {
        if (this == obj)
        {
            return true;
        }
        else if (!(obj is ResourceLocation resourceLocation))
        {
            return false;
        }
        else
        {
            return ResourceDomain.Equals(resourceLocation.ResourceDomain) &&
                   ResourcePath.Equals(resourceLocation.ResourcePath);
        }
    }

    public override int GetHashCode()
    {
        return 31 * ResourceDomain.GetHashCode() + ResourcePath.GetHashCode();
    }
}