using Minecraft1_8_9Port.org.apache.logging.log4j;

namespace Minecraft1_8_9Port.net.minecraft.util;

public class RegistrySimple<TKey, TValue> : IRegistry<TKey, TValue>
{
    private static readonly Logger logger = LogManager.getLogger();
    protected readonly Dictionary<TKey, TValue> registryObjects = createUnderlyingMap();
    
    protected static Dictionary<TKey, TValue> createUnderlyingMap()
    {
        return new Dictionary<TKey, TValue>();
    }

    public TValue getObject(TKey name)
    {
        return registryObjects.TryGetValue(name, out TValue value) ? value : default;
    }

    public void putObject(TKey key, TValue value)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (registryObjects.ContainsKey(key))
        {
            logger.debug($"Adding duplicate key '{key}' to registry");
        }

        registryObjects[key] = value;
    }

    public ICollection<TKey> getKeys()
    {
        return new List<TKey>(registryObjects.Keys);
    }

    public bool containsKey(TKey key)
    {
        return registryObjects.ContainsKey(key);
    }

    public IEnumerator<TValue> GetEnumerator()
    {
        return registryObjects.Values.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}