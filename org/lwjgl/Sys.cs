using System.Diagnostics;

namespace Minecraft1_8_9Port.org.lwjgl;

public class Sys
{
    private static readonly long timerResolution = Stopwatch.Frequency;
    private static readonly long startTime = Stopwatch.GetTimestamp();

    public static long getTime()
    {
        return Stopwatch.GetTimestamp() - startTime;
    }
    
    public static long getTimerResolution()
    {
        return timerResolution;
    }
}