namespace Minecraft1_8_9Port.net.minecraft.util;

public interface IRegistry<TKey, TValue> : IEnumerable<TValue>
{
    TValue getObject(TKey name);

    void putObject(TKey key, TValue value);
}