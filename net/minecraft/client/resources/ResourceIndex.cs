using Minecraft1_8_9Port.org.apache.logging.log4j;
using Newtonsoft.Json;

namespace Minecraft1_8_9Port.net.minecraft.client.resources;

public class ResourceIndex
{
    private static readonly Logger logger = LogManager.getLogger();
    private readonly Dictionary<string, FileInfo> resourceMap = new Dictionary<string, FileInfo>();

    public ResourceIndex(DirectoryInfo directoryInfo, string indexName)
    {
        if (indexName != null)
        {
            DirectoryInfo objectsDirectory = new DirectoryInfo(Path.Combine(directoryInfo.FullName, "objects"));
            FileInfo indexFile = new FileInfo(Path.Combine(directoryInfo.FullName, $"indexes/{indexName}.json"));
            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(indexFile.FullName);
                var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(streamReader.ReadToEnd());
                var objectsJson = jsonObject.ContainsKey("objects")
                    ? (Dictionary<string, object>)jsonObject["objects"]
                    : null;

                if (objectsJson != null)
                {
                    foreach (var entry in objectsJson)
                    {
                        var jsonObjectEntry = (Dictionary<string, object>)entry.Value;
                        string key = entry.Key;
                        string[] splitKey = key.Split('/', 2);
                        string formattedKey = splitKey.Length == 1 ? splitKey[0] : $"{splitKey[0]}:{splitKey[1]}";
                        string hash = jsonObjectEntry.ContainsKey("hash")
                            ? jsonObjectEntry["hash"].ToString()
                            : string.Empty;
                        FileInfo resourceFile = new FileInfo(Path.Combine(objectsDirectory.FullName,
                            $"{hash.Substring(0, 2)}/{hash}"));
                        this.resourceMap[formattedKey] = resourceFile;
                    }
                }
            }
            catch (JsonException)
            {
                logger.error($"Unable to parse resource index file: {indexFile}");
            }
            catch (FileNotFoundException)
            {
                logger.error($"Can't find the resource index file: {indexFile}");
            }
            finally
            {
                streamReader?.Close();
            }
        }
    }

    public Dictionary<string, FileInfo> getResourceMap()
    {
        return this.resourceMap;
    }
}