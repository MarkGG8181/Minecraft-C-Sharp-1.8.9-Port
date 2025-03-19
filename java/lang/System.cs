using System.Diagnostics;

namespace Minecraft1_8_9Port.java.lang;

public class System
{
    public static long nanoTime(){
        return (Stopwatch.GetTimestamp() * 1_000_000_000L) / Stopwatch.Frequency;
    }
}