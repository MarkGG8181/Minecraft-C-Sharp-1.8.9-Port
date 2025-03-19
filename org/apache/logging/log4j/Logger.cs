namespace Minecraft1_8_9Port.org.apache.logging.log4j;

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
    
    public void debug(String message) {
        Console.WriteLine(message);
    }
}