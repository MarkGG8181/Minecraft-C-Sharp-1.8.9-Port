using Minecraft1_8_9Port.net.minecraft.client;

namespace Minecraft1_8_9Port;

public class Logger {
    public void info(String message) {
        Console.WriteLine(message);
    }
    
    public void error(String message) {
        Console.Error.WriteLine(message);
    }
    
    public void warn(String message) {
        Console.WriteLine(message);
    }
}