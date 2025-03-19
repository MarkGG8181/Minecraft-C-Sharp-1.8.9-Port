using System.Drawing;
using Minecraft1_8_9Port.net.minecraft.client.resources.data;
using Minecraft1_8_9Port.org.apache.logging.log4j;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.Json.Nodes;
using Minecraft1_8_9Port.net.minecraft.client.renderer.texture;
using Newtonsoft.Json;
using ResourceLocation = Minecraft1_8_9Port.net.minecraft.util.ResourceLocation;

namespace Minecraft1_8_9Port.net.minecraft.client.resources;

public abstract class AbstractResourcePack : IResourcePack
{
    private static readonly Logger resourceLog = LogManager.getLogger();
    public FileInfo resourcePackFile;

    public AbstractResourcePack(FileInfo resourcePackFileIn)
    {
        this.resourcePackFile = resourcePackFileIn;
    }

    private static string locationToName(ResourceLocation location)
    {
        return $"assets/{location.getResourceDomain()}/{location.getResourcePath()}";
    }

    protected static string getRelativeName(string basePath, string targetPath)
    {
        Uri baseUri = new Uri(basePath);
        Uri targetUri = new Uri(targetPath);
        Uri relativeUri = baseUri.MakeRelativeUri(targetUri);
        return relativeUri.ToString();
    }

    public Stream getInputStream(ResourceLocation location)
    {
        return this.getInputStreamByName(locationToName(location));
    }

    public bool resourceExists(ResourceLocation location)
    {
        return this.hasResourceName(locationToName(location));
    }

    protected abstract Stream getInputStreamByName(string name);

    protected abstract bool hasResourceName(String name);

    protected void logNameNotLowercase(String name)
    {
        resourceLog.warn($"ResourcePack: ignored non-lowercase namespace: {name} in {this.resourcePackFile}");
    }
    
    //TODO: finish: getPackMetadata, readMetadata

    /*
    public T getPackMetadata<T>(IMetadataSerializer metadataSerializer, string metadataSectionName)
        where T : IMetadataSection
    {
        return readMetadata<T>(metadataSerializer, this.getInputStreamByName("pack.mcmeta"), metadataSectionName);
    }

    public static T readMetadata<T>(IMetadataSerializer serializer, Stream inputStream, string metadataKey)
        where T : IMetadataSection
    {
        JsonObject jsonObject = null;
        StreamReader streamReader = null;

        try
        {
            streamReader = new StreamReader(inputStream, System.Text.Encoding.UTF8);
            jsonObject = JsonConvert.DeserializeObject<JsonObject>(streamReader.ReadToEnd());
        }
        catch (Exception ex)
        {
            throw new JsonException("Error parsing JSON.", ex);
        }
        finally
        {
            streamReader?.Dispose();
        }

        return serializer.parseMetadataSection<T>(metadataKey, jsonObject);
    }
    */

    public Bitmap getPackImage()
    {
        return TextureUtil.readBufferedImage(this.getInputStreamByName("pack.png"));
    }

    public string getPackName()
    {
        return this.resourcePackFile.Name;
    }

    public HashSet<string> getResourceDomains()
    {
        throw new NotImplementedException();
    }
}