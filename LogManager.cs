namespace Minecraft1_8_9Port;

public class LogManager
{
    private static readonly Logger logger = new Logger();

    public static Logger getLogger()
    {
        return logger;
    }
}